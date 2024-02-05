import { Component, ViewChild, TemplateRef, Inject, LOCALE_ID } from '@angular/core';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from "@angular/material/icon";
import { CandidateService } from 'src/app/shared/Services/CandidateService/candidate.service';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import * as XLSX from "xlsx";
import { Router } from '@angular/router';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { DatePipe, formatDate } from '@angular/common';
import { StatusService } from 'src/app/shared/Services/StatusService/status.service';
import { ExcelService } from 'src/app/shared/Services/ExcelService/excel.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSelect } from '@angular/material/select';
import { cloneWith, max } from 'lodash';

class ImageSnippet {
  constructor(public src: string, public file: File) {}
}
@Component({
  selector: 'app-candidate-details',
  templateUrl: './candidate-details.component.html',
  styleUrls: ['./candidate-details.component.css']
})

export class CandidateDetailsComponent {
  @ViewChild('modalContent') modalContent!: TemplateRef<any>;
  @ViewChild(MatPaginator) paginator: MatPaginator
  @ViewChild(MatSort) sort: MatSort;
  toppings = new FormControl();
  displayedColumns: string[] =
    ['candidateUid',
      'candidateName',
     
      'email',
 
      'skills',
      'joiningDate',
   
     
      'isInternal',
      'panNumber'
    ];
  advancedColumns: string[] = [
    'Select All',
    'status',
    'location',
    'address',
    'pincode',
    'gender',
    'mobileNo',
    'dob'
  ]


  isSelectAllChecked: boolean = false;
  updatedcontroller: string[] = [];
  Image: any
  onOptionClick(column: string, matSelectRef: MatSelect): void {
    if (column === 'Select All') {
      this.handleAdvancedViewChange();
      matSelectRef.close();
    } else {
      this.AddColumns(column);
    }
  }
 
  handleAdvancedViewChange() {
 
    if (this.isSelectAllChecked == false) {
      this.updatedcontroller = [];
      this.updatedcontroller.push('Select All')
      for (var i = 1; i < this.advancedColumns.length; i++) {
        if (this.toppings.value.includes(this.advancedColumns[i])) {
          this.updatedcontroller.push(this.advancedColumns[i])
        }
        else {
          this.AddColumns(this.advancedColumns[i]);
          this.updatedcontroller.push(this.advancedColumns[i])
        }
      }
 
      this.toppings.setValue(this.updatedcontroller);
      this.isSelectAllChecked = true;
    }
    else {
 
      for (var i = 1; i < this.advancedColumns.length; i++) {
 
 
        this.AddColumns(this.advancedColumns[i]);
 
      }
      this.updatedcontroller = [];
      this.toppings.setValue([]);
      this.isSelectAllChecked = false;
    }
 
  }
 
  AddColumns(columnname: string) {
    const Index = this.displayedColumns.indexOf(columnname);
 
    if (Index === -1) {
      const internalResourceIndex = this.displayedColumns.indexOf('isInternal');
      if (internalResourceIndex !== -1) {
        this.displayedColumns.splice(internalResourceIndex + 1, 0, columnname);
      }
    }
    else {
      if (Index !== -1) {
        this.displayedColumns.splice(Index, 1);
      }
 
    }
   
    if (this.displayedColumns.length == 15) {
      this.updatedcontroller = [];
      this.updatedcontroller = this.toppings.value.filter((column: any) => column !== 'Select All');
      this.updatedcontroller.push('Select All')
      this.toppings.setValue(this.updatedcontroller);
 
      console.log(this.updatedcontroller)
 
      this.isSelectAllChecked = true;
    }
    else {
      this.updatedcontroller = [];
      this.updatedcontroller = this.toppings.value.filter((column: any) => column !== 'Select All');
 
      this.toppings.setValue(this.updatedcontroller);
      this.isSelectAllChecked = false;
    }
 
  }
 
  dataSource!: MatTableDataSource<any>;

  file: File;
  arrayBuffer: any;
  filelist: any;
  isEditing: boolean = false;
  isAuthor: any;
  candidatesList: any;
  statusList: any;
  StatusNames:string[]= [];
  filteredCandidates: any[];
  downloadData: any = [];
  isInternal: string;
  downloadObject: any;
  isFormVisible: boolean = false;
  User: any;
  IsAccessToEdit: boolean = true;
  maxDate: Date;
  selectedFile: ImageSnippet;
  selectedImage: File;
  pandata:any

  constructor(
    private _candidateService: CandidateService,
    @Inject(LOCALE_ID) public locale: string,
    private _excelService: ExcelService,
    public _statusService: StatusService,
    private _router: Router,
    private snackBar: MatSnackBar,
    public dialog: MatDialog,

  ) { this.maxDate = new Date() }
  ngOnInit(): void {

    this.User = JSON.parse(sessionStorage.getItem("userData") as string);
    this.IsAccessToEdit = this.User.PermissionName === "Edit" ? true : false;
    console.log(this.IsAccessToEdit)
    if (this.IsAccessToEdit) {
      this.displayedColumns.push('actions');
    }
    this.isAuthor = JSON.parse(sessionStorage.getItem("author") as string);
    this.GetCandidateData();
    console.log(this.GetCandidateData)
    // this.filteredCandidates = this.candidatesList
    this.GetStatusByType();
    //this.importCandidatePAN()
  
  }
  

  exportEmptyExcel() {
    const headers = [
      'CandidateUid',
      'CandidateName',
      'MobileNo',
      'Gender',
      'DOB',
      'Email',
      'Location',
      'Skills',
      'JoiningDate',
      'Address',
      'Status',
      'Pincode',
      'isInternal',
      'pan'

    ];
    const panImageBase64 = 'your_base64_encoded_pan_image_here';

    this._excelService.exportEmptyExcelFile('CandidateTemplateExcel', headers);
  }

  GetCandidateData() {
    this._candidateService.GetAllCandidatesData().subscribe(
      (data) => {
        console.log(data)

        this.candidatesList = data;
        this.dataSource = new MatTableDataSource(data);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
        // console.log(this.dataSource.filteredData)

      },
      (err) => {
        console.log(err);
      }
    );
  }
  // getPANById(row:any)
  // {
  //   this.pandata = this.candidatesList.filter((x:any) => x.candidateId === row.candidateId);

  //   const dialogRef = this.dialog.open(this.modalContent);

  //       console.log(this.pandata)
  // }


  getPANById(row:any)
  {
      let candidateId = row.candidateId
      
    console.log(candidateId)
    sessionStorage.setItem("candidateId", candidateId)
    if (candidateId) {
      this._candidateService.GetCandidateById(candidateId).subscribe((r) => {
        this.pandata = r;
        const dialogRef = this.dialog.open(this.modalContent);

        console.log(this.pandata)
        
        //this.pandata=this.pandata[0].jobDesc.split("\n\u2022 ")
       // console.log(this.pandata);
      })
    }
    console.log(this.pandata)
  }

  GetStatusByType() {
    this._statusService.GetStatusByType('Candidate').subscribe((result: any) => {
      this.statusList = result;
  
      this.StatusNames = this.statusList.map((status: { statusName: string }) => status.statusName);
  
      console.log(this.statusList);
    });
  }
  

  toggleFormVisibility() {
    this.isFormVisible = !this.isFormVisible;

  }
  // FIlter
  filterForm = new FormGroup({
    candidateUid: new FormControl(''),
    candidateName: new FormControl(''),
    dobFrom: new FormControl(''),
    dobTo: new FormControl(''),
    gender: new FormControl(''),
    status: new FormControl(''),
    joiningDateFrom: new FormControl(''),
    joiningDateTo: new FormControl(''),
    skills: new FormControl(''),
    location: new FormControl(''),
    isInternal: new FormControl(''),
    address: new FormControl(''),
    pincode: new FormControl(''),
    mobileNo: new FormControl(''),
    email: new FormControl(''),
    pan:new FormControl('')
  })

  restCustomFilter() {
    this.filterForm.reset()
    this.customFilter()
    this.toggleFormVisibility()
  }
  clearFormField(fieldName: string): void {
    this.filterForm.get(fieldName)?.setValue('');
    this.customFilter()
  }



  customFilter(): void {
    let uidFilter = this.filterForm.value.candidateUid;
    let candidateNameFilter = this.filterForm.value.candidateName;
    let genderFilter = this.filterForm.value.gender;
    let statusFilter = this.filterForm.value.status;
    let skillsFilter = this.filterForm.value.skills;
    let locationFilter = this.filterForm.value.location;
    let isInternalFilter = this.filterForm.value.isInternal;
    let dobFromFilter = this.filterForm.value.dobFrom;
    let dobToFilter = this.filterForm.value.dobTo;
    let joiningDateFromFilter = this.filterForm.value.joiningDateFrom;
    let joiningDateToFilter = this.filterForm.value.joiningDateTo;
    let pan = this.filterForm.value.pan


    this.filteredCandidates = this.candidatesList.filter((item: any) => {

      if (uidFilter && !item.candidateUid.startsWith(uidFilter)) {
        return false;

      }



      if (candidateNameFilter && !item.candidateName.toLowerCase().startsWith(candidateNameFilter.toLowerCase())) {
        return false;
      }
      if (pan && !item.pan.toLowerCase().startsWith(pan.toLowerCase())) {
        return false;
      }
      if (genderFilter && item.gender.toLowerCase() !== genderFilter.toLowerCase()) {
        return false;
      }

      if (statusFilter && item.status.toLowerCase() !== statusFilter.toLowerCase()) {
        return false;
      }

      if (skillsFilter && !item.skills.toLowerCase().includes(skillsFilter.toLowerCase())) {
        return false;
      }

      if (locationFilter && !item.location.toLowerCase().startsWith(locationFilter.toLowerCase())) {
        return false;
      }

      if (isInternalFilter !== null && isInternalFilter !== undefined) {
        if (isInternalFilter && (isInternalFilter === 'true' && !item.isInternal) || (isInternalFilter === 'false' && item.isInternal)) {
          return false;
        }
      }

      if (dobFromFilter && dobToFilter && !((new Date(item.dob) >= new Date(dobFromFilter)) && (new Date(item.dob) <= new Date(dobToFilter)))) {
        return false;
      }

      if (joiningDateFromFilter && joiningDateToFilter && !((new Date(item.joiningDate) >= new Date(joiningDateFromFilter)) && (new Date(item.joiningDate) <= new Date(joiningDateToFilter)))) {
        return false;
      }
      return true;
    });

    // console.table(filteredArray)
    this.dataSource = new MatTableDataSource(this.filteredCandidates);
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  // UPDATE
  selectRow(item: any) {
    this.dataSource.data.forEach((element: any) => {
      element.isEditing = false
    });
    item.isEditing = true;
  }

  cancelUpdate(item: any) {
    item.isEditing = false;
  }

  onImageSelected(event: any) {
    this.file = event.target.files[0];
    console.log(this.file)
  
    const reader = new FileReader();
    reader.readAsDataURL(this.file);
    reader.onload = () => {
      const base64Image = reader.result!.toString();
  
      this.Image = base64Image
    };

    
  }

  UpdateCandidateData(item: any) {
    if (item) {
      item.isEditing = false;
      delete item.isEditing;
      item.dob = (this.formatdate(item.dob) + "T00:00:00.00Z")
      item.joiningDate = (this.formatdate(item.joiningDate) + "T00:00:00.00Z");
      console.log(this.Image)
  item.pan=this.Image
   console.log(this.Image)
   console.log(item.pan)
      // console.log(item)
    }
    this._candidateService.UpdateCandidateData(item.candidateId, item).subscribe(
      (data) => {
        console.log(item)
        this.openSnackBar("Successfully Updated", "ok")

      },
      (err) => {
        console.log(err);
      }
    )
  }
  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 2000,
      verticalPosition:'bottom',
      panelClass:['red-snackbar']
    });
    
  }

  DownloadExcel() {

    console.log(this.statusList)
    console.log(this.StatusNames)
    let filteredData: any = []
    if (!this.filteredCandidates) {
      filteredData = this.dataSource.filteredData;
    } else {
      filteredData = this.filteredCandidates;
    }
    if (filteredData.length > 0) {
      let headers = [
        'CandidateUid',
        'CandidateName',
        'MobileNo',
        'Gender',
        'DOB',
        'Email',
        'Location',
        'Skills',
        'JoiningDate',
        'Address',
        'Status',
        'Pincode',
        'isInternal',
        'panNumber',
        'pan'
  
      ];
    
      const downloadData = filteredData.map((data: any) => ({
        "CandidateUid": data.candidateUid,
        "CandidateName": data.candidateName,
        "MobileNo": data.mobileNo,
        "Gender": data.gender,
        "DOB": (data.dob==='1900-01-01T00:00:00'?null:data.dob),
    
        "Email": data.email,
        "Location": data.location,
        "Skills": data.skills,
        "JoiningDate": (data.joiningDate==='1900-01-01T00:00:00'?null:data.dob),
 
       // "Address": data.address,
        "Address": (data.address==='<<<No Data>>>'?null:data.address),
        "Status": data.status,
       // "Pincode": data.pincode,
        "Pincode": (data.pincode==='<<<No Data>>>'?null:data.pincode),
        "isInternal": data.isInternal ? this.isInternal = "Yes" : this.isInternal = "No" ,
        'panNumber':data.panNumber,
       
        'pan':data.pan ? data.pan.substring(0, max) : ''


      }));

     // this._excelService.jsonExportAsExcel(downloadData, "Candidate Details", headers);
     this._excelService.jsonExportAsExcelExperiment(downloadData, "Candidate Details", headers,this.StatusNames);


    } else {
      alert('No Records found!');
    }
  }
  
  inputDate1: any;

  onFileSelected(event: any) {

    this.file = event.target.files[0];
    let fileReader = new FileReader();
    fileReader.readAsArrayBuffer(this.file);
    fileReader.onload = (e) => {
      this.arrayBuffer = fileReader.result;
      var data = new Uint8Array(this.arrayBuffer);
      var arr = new Array();
      for (var i = 0; i != data.length; ++i)
        arr[i] = String.fromCharCode(data[i]);
      var bstr = arr.join("");
      var workbook = XLSX.read(bstr, { type: "binary" });
      var first_sheet_name = workbook.SheetNames[0];
      var worksheet = workbook.Sheets[first_sheet_name];
      this.filelist = XLSX.utils.sheet_to_json(worksheet, { raw: true });
      // console.table(this.filelist)

      this.filelist.forEach((element: any) => {
        element.CandidateUid = JSON.stringify(element.CandidateUid);
        element.MobileNo = JSON.stringify(element.MobileNo);
        element.Pincode = JSON.stringify(element.Pincode);
        element.isInternal = element.isInternal.toLowerCase() === 'yes' ? true : false;
        console.table(element.DOB==undefined)
        const serialNumber1 = element.DOB;
        element.DOB = new Date(XLSX.SSF.format('yyyy-mm-dd', serialNumber1));
        const serialNumber2 = element.JoiningDate;
        element.JoiningDate = new Date(XLSX.SSF.format('yyyy-mm-dd', serialNumber2));
        element.pan = JSON.stringify(element.pan)
       // element.pan=JSON.stringify(element.pan)
      });


      console.log(this.filelist)

      this._candidateService.PostCandidateDuplicateCheck(this.filelist).subscribe((x) => {
        this.openSnackBar(x, "ok")
        console.log(x)
        event.target.value = ''
        this.GetCandidateData()

      },
      (err) => {
        console.log(err);
      }
        

        
    
      );
    };
  }

  deleteDetails(candidate: any) {
    if (confirm("Do you want to delete record of " + candidate.candidateName)) {
      this._candidateService.DeleteCandidateData(candidate.candidateId).subscribe((res) => {
        this.openSnackBar("Successfully Deleted", "ok")
        this.GetCandidateData();
      },
      (err) => {
        console.log(err);
      }
       
      );
    }

  }

  formatdate(date: any) {
    return formatDate(date, 'yyyy-MM-dd', this.locale);
  }

  importCandidatePAN() {
    // Create a FormData object
    const formData = new FormData();
 
    // Append the candidatesList as a JSON string
    formData.append('candidates', JSON.stringify(this.candidatesList));
 
    // Append the selected image file
    if (this.selectedImage) {
      formData.append('image', this.selectedImage, this.selectedImage.name);
    }
 
    // Make the HTTP request with the FormData
    this._candidateService.importCandidatePAN(formData)
      .subscribe(
        (response) => {
          console.log('Import success:', response);
        },
        (error) => {
          console.error('Import error:', error);
        }
      );
  }
  
  onFileChange(event: any) {
    const fileList: FileList = event.target.files;
    if (fileList.length > 0) {
      this.selectedImage = fileList[0];
    }
  }



}
