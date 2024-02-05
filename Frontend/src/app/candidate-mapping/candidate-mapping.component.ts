import { Component, ElementRef, Inject, LOCALE_ID, TemplateRef, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { CandidateMappingService } from '../shared/Services/CandidateMappingService/candidate-mapping.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { CandidateService } from '../shared/Services/CandidateService/candidate.service';
import { SoService } from '../shared/Services/SoService/so.service';
import { StatusService } from '../shared/Services/StatusService/status.service';
import { FormControl, FormGroup, FormGroupDirective, Validators } from '@angular/forms';
import { ExcelService } from '../shared/Services/ExcelService/excel.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { formatDate } from '@angular/common';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
@Component({
  selector: 'app-candidate-mapping',
  templateUrl: './candidate-mapping.component.html',
  styleUrls: ['./candidate-mapping.component.css']
})
export class CandidateMappingComponent {
  SOData: any[] = [];
  CandidateData: any[] = [];
  StatusData: any[] = [];
  MappingsList: any = [];
  MappingData: any = [];
  downloadObject: any;
  CandidateMappingData: any = [];
  Id: any = null;
  submitted: boolean = false;
  displayedColumns: string[] = ['soName', 'candidateName',
    'status', 'mappingDate'];
  dataSource!: MatTableDataSource<any>;
  selectedStatus: any = '';
  mappingDate: any
  User: any;
  isAdmin: boolean = true;


  @ViewChild(MatPaginator) paginator: MatPaginator
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild('modalContent') modalContent!: TemplateRef<any>;

  @ViewChild('soNameVar') soNameFilterVar: any = '';
  @ViewChild('candidateNameVar') candidateNameFilterVar: any = '';
  filteredMappingArray: any
  isFormVisible: boolean = false;




  constructor(
    private service: CandidateMappingService,
    public dialog: MatDialog, private candidateservice: CandidateService,
    private sowService: SoService,
    private statusService: StatusService,
    private excelService: ExcelService,
    private snackBar: MatSnackBar,
    @Inject(LOCALE_ID) public locale: string,
  ) { }
  async ngOnInit() {
    this.User = JSON.parse(sessionStorage.getItem("userData") as string);
    this.isAdmin = this.User.RoleName === "Admin" ? true : false;
    if (this.isAdmin) {
      this.displayedColumns.push('actions');
    }
    await this.GetSOData();
    await this.GetCandidateData();
    await this.GetStatusData();

    this.GetCandidateMappingData();
    this.SOControl.valueChanges.subscribe((value) => {
      this.filteredSO = this.SOData.filter((SO) =>
        SO.soName.toLowerCase().includes(value?.toLowerCase() || '')
      )
    });
    this.CandidateControl.valueChanges.subscribe((value) => {
      this.filteredCandidate = this.CandidateData.filter((candidate) =>
      candidate.candidateName.toLowerCase().includes(value?.toLowerCase() || '')
      )
    });


  }


  


  applyEdit(candidate: any) {

    candidate.isEditing = true;
  }

  cancelEdit(candidate: any) {
    candidate.isEditing = false;
  }
  UpdateCandidate(candidate: any) {
    console.log(candidate)
    candidate.mappingDate = formatDate(candidate.mappingDate as string, 'yyyy-MM-dd', this.locale);
    console.log(candidate)
    this.service.UpdateCandidateMappingData(candidate.soW_CandidateId, candidate).subscribe(res => {
      candidate.isEditing = false;

      this.openSnackBar("Successfully Updated", "ok")
      this.GetCandidateMappingData();
    }, err => {
      console.log(err)
    })
  }
  toggleFormVisibility() {
    this.isFormVisible = !this.isFormVisible;

  }
  GetCandidateMappingData() {
    this.service.GetAllCandidateMappingData().subscribe(
      (data) => {
        console.log(data)
        this.dataSource = new MatTableDataSource(data);
        this.CandidateMappingData = data;
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;

      },
      (err) => {
        console.log(err);
      }
    );
  }
  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 2000,

      verticalPosition: 'bottom',

    });
  }
  openModal(): void {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '1000px';

    const dialogRef = this.dialog.open(this.modalContent);
    dialogRef.afterClosed().subscribe(result => {

    });
  }

  closeModal(formDirective: FormGroupDirective): void {
    formDirective.resetForm();
    this.mapppingForm.reset(); // Reset the form
    this.SOControl.reset();
    this.CandidateControl.reset();
    this.dialog.closeAll();
  }

  mapppingForm = new FormGroup({
    candidateId: new FormControl('', [Validators.required]),
    candidateName: new FormControl('', [Validators.required]),

    sowId: new FormControl('', [Validators.required]),
    soName: new FormControl('', [Validators.required]),
    statusId: new FormControl('', [Validators.required]),
    mappingDate: new FormControl('', [Validators.required])
  })

  get f() { return this.mapppingForm.controls; }

  SOControl = new FormControl('', [Validators.required]);

  filteredSO: any[] = [];
  CandidateControl = new FormControl('', [Validators.required]);

  filteredCandidate: any[] = [];

  onSubmit(formDirective: FormGroupDirective) {
    console.log(this.mapppingForm.value)

    this.mapppingForm.value.mappingDate = formatDate(this.mapppingForm.value.mappingDate as string, 'yyyy-MM-dd', this.locale);
    this.submitted = true;
    console.log(this.mapppingForm)
    if (this.mapppingForm.invalid) {
      this.markAllFieldsAsUntouched();

      return;
    }
    else {
      console.log(this.mapppingForm)
      this.onAdd(formDirective);

    }
  }


  isFieldInvalid(fieldName: string): boolean {
    const control = this.mapppingForm.get(fieldName);
    return control !== null && control.invalid && (control.touched || this.submitted);
  }

  markAllFieldsAsUntouched() {
    Object.keys(this.mapppingForm.controls).forEach(fieldName => {
      this.mapppingForm.controls[fieldName as keyof typeof this.mapppingForm.controls].markAsUntouched();
    });
  }

  onAdd(formDirective: FormGroupDirective) {
    let formValue = this.mapppingForm.value;
    let obj = {
      sowId: formValue.sowId,
      candidateId: formValue.candidateId,
      StatusId: formValue.statusId,
      mappingDate: formValue.mappingDate,
      type: "post",
    };
    this.service.PostCandidateMappingData(obj).subscribe(data => {
      console.log(data)
      this.openSnackBar(data, 'Ok')
      formDirective.resetForm();
      this.mapppingForm.reset();
      this.SOControl.reset();
      this.CandidateControl.reset();

      this.GetCandidateMappingData();
    })
  }
  onOptionSelectedSO(event: MatAutocompleteSelectedEvent) {
    const selectedValueSO = event.option.value;
    const SONameControl = this.mapppingForm.get('soName');
    if (SONameControl) {
      SONameControl.setValue(selectedValueSO);
      SONameControl.markAsTouched;
    }
    let matchingSOW = this.SOData.find(x => x.soName === this.mapppingForm.value.soName);

    const selectedValueSOWid = matchingSOW.sowId;
    const SOControl = this.mapppingForm.get('sowId');
    if (SOControl) {
      SOControl.setValue(selectedValueSOWid);
      SOControl.markAsTouched;
    }

  }
  onOptionSelectedCandidate(event: MatAutocompleteSelectedEvent) {
    const selectedValuecandidatename = event.option.value;
    const candidateNameControl = this.mapppingForm.get('candidateName');
    if (candidateNameControl) {
      candidateNameControl.setValue(selectedValuecandidatename);
      candidateNameControl.markAsTouched;
    }
    let matchingCandidate = this.CandidateData.find(x => x.candidateName === this.mapppingForm.value.candidateName);

    const selectedValuecandidateId = matchingCandidate.candidateId;
    const CandidateIdControl = this.mapppingForm.get('candidateId');
    if (CandidateIdControl) {
      CandidateIdControl.setValue(selectedValuecandidateId);
      CandidateIdControl.markAsTouched;
    }

  }

  


  deleteDetails(map: any) {
    this.Id = map.soW_CandidateId;
    var decision = confirm('Are you sure you want to delete?');
    if (decision) {
      this.service.DeleteCandidateMappingData(map.soW_CandidateId).subscribe(res => {

        this.openSnackBar(res, 'Ok')
        this.GetCandidateMappingData();
        this.Id = null;
      })
    }
    else {
      this.openSnackBar('Data not Deleted', 'Ok')

    }
  }



  GetSOData() {
    this.sowService.GetAllSowDataForSoCandidateMapping().subscribe(data => {
      this.SOData = data;
      this.filteredSO = data;

      console.log(this.SOData)


    })
  }


  GetCandidateData() {
    return new Promise((res, rej) => {
      this.candidateservice.GetAllCandidateDataForSoCandidateMapping().subscribe(data => {
        this.CandidateData = data;
        this.filteredCandidate=data;
        console.log(data)
        res('')
      })
    })
  }

  GetStatusData() {
    return new Promise((res, rej) => {
      let statustype = "SoCandidate";
      this.statusService.GetStatusByType(statustype).subscribe(data => {
        this.StatusData = data;
        res('')
      })
    })
  }

  DownloadExcel() {

    let filteredData: any = []
    if (!this.filteredMappingArray) {
      filteredData = this.dataSource.filteredData;
    } else {
      filteredData = this.filteredMappingArray;
    }
    if (filteredData.length > 0) {
      let headers = ['SO Name', 'Candidate Name', 'Status', 'MappingDate']
      const downloadData = filteredData.map((data: any) => ({
        'SO Name': data.soName,
        'Candidate Name': data.candidateName,
        'Status': data.statusName,
        'MappingDate': data.mappingDate
      }));

      this.excelService.jsonExportAsExcel(downloadData, "SOCandidate Mapping", headers);

    } else {

      this.openSnackBar('No Records found!', 'Ok')
    }
  }

  customFilter() {
    let filterObject: any = {
      soName: this.soNameFilterVar.nativeElement.value,
      candidateName: this.candidateNameFilterVar.nativeElement.value,
      statusName: this.selectedStatus,


    }
    console.log(filterObject)
    this.filteredMappingArray = this.CandidateMappingData.filter((element: any) =>
      (filterObject.soName === '' || element.soName.toLowerCase().startsWith(filterObject.soName.toLowerCase())) &&
      (filterObject.candidateName === '' || element.candidateName.toLowerCase().startsWith(filterObject.candidateName.toLowerCase())) &&
      (filterObject.statusName === '' || element.statusName.toLowerCase().startsWith(filterObject.statusName.toLowerCase()))

    );
    this.dataSource = new MatTableDataSource(this.filteredMappingArray);
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }
}
