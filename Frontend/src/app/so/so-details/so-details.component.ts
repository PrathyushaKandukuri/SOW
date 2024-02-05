import { AfterViewInit, Component, ElementRef, HostListener, Inject, LOCALE_ID, OnInit, Pipe, PipeTransform, QueryList, TemplateRef, ViewChild, ViewChildren, inject } from '@angular/core';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import * as XLSX from 'xlsx';
import { SOModel } from 'src/app/Models/SOModel';
import { FormBuilder, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AccountModel } from 'src/app/Models/AccountModel';
import { DellManagerModel } from 'src/app/Models/DellManagerModel';
import { LocationModel } from 'src/app/Models/LocationModel';
import { MappingModel } from 'src/app/Models/MappingModel';
import { RecruiterModel } from 'src/app/Models/RecruiterModel';
import { RegionModel } from 'src/app/Models/RegionModel';
import { StatusModel } from 'src/app/Models/StatusModel';
import { TechnologyModel } from 'src/app/Models/TechnologyModel';
import { USTPOCModel } from 'src/app/Models/USTPOCModel';
import { USTTPMModel } from 'src/app/Models/USTTPMModel';
import { SoService } from 'src/app/shared/Services/SoService/so.service';
import { RegionService } from 'src/app/shared/Services/RegionService/region.service';
import { LocationService } from 'src/app/shared/Services/LocationService/location.service';
import { AccountService } from 'src/app/shared/Services/AccountService/account.service';
import { UstTpmService } from 'src/app/shared/Services/UsttpmService/ust-tpm.service';
import { UstPocService } from 'src/app/shared/Services/UstpocService/ust-poc.service';
import { RecruiterService } from 'src/app/shared/Services/RecruiterService/recruiter.service';
import { DellManagerService } from 'src/app/shared/Services/DellManagerService/dell-manager.service';
import { StatusService } from 'src/app/shared/Services/StatusService/status.service';
import { TechnologyService } from 'src/app/shared/Services/TechnologyService/technology.service';
import { CandidateMappingService } from 'src/app/shared/Services/CandidateMappingService/candidate-mapping.service';
import { ExcelService } from 'src/app/shared/Services/ExcelService/excel.service';
import { MatDateRangeInput, MatDatepicker } from '@angular/material/datepicker';
import { formatDate } from '@angular/common';
import { MatSnackBar } from '@angular/material/snack-bar';
import { HttpClient } from '@angular/common/http';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { ThemePalette } from '@angular/material/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { ScreeningComponent } from 'src/app/ScreeningE/screening/screening.component';
import { RoleDetails } from 'src/app/Models/Roledetails';
import { RoledetailsService } from 'src/app/roledetails.service';
import { MatSlideToggleChange } from '@angular/material/slide-toggle';
import { MatSelect } from '@angular/material/select';


@Component({
  selector: 'app-so-details',
  templateUrl: './so-details.component.html',
  styleUrls: ['./so-details.component.css'],
})
export class SoDetailsComponent implements OnInit {
  file: File;
  sopush: [] = [];
  arrayBuffer: any;
  filelist: any;
  filelist1: any;
  Id: any = null;
  editmode: boolean = false;
  sowlist: SOModel[] = [];
  regionList: RegionModel[] = [];
  accountList: AccountModel[] = [];
  technologyList: TechnologyModel[] = [];
  locationList: LocationModel[] = [];
  ustPocList: USTPOCModel[] = [];
  ustTpmList: USTTPMModel[] = [];
  recruiterList: RecruiterModel[] = [];
  dellManagerList: DellManagerModel[] = [];
  statusList: StatusModel[] = [];
  mappinglst: MappingModel[] = [];
  roledetailslist: RoleDetails[] = []
  selectedRegionId: string = '';
  isRegionSelected: boolean = false;
  fromDate: Date | null | any = null;
  endDate: Date | null | any = null;
  startDate: Date | null = null;
  isFormVisible: boolean = false;
  dataSource: MatTableDataSource<any>;
  picker: MatDatepicker<any>;
  rangeInput: MatDateRangeInput<Date>;
  soData: any;
  User: any;
  IsAccessToEdit: boolean = true;
  maxDate: Date;
  JobDescription:any;

  jobdescdata: any; 
  usttpmControl = new FormControl();
  filteredUSTTPM: USTTPMModel[] = [];

  accountControl = new FormControl();
  filteredaccount: AccountModel[] = [];

  technologyControl = new FormControl();
  filteredtechnology: TechnologyModel[] = [];

  regionControl = new FormControl();
  filteredregion: RegionModel[] = [];

  locationControl = new FormControl();
  filteredlocation: LocationModel[] = [];

  USTPOCControl = new FormControl()
  filteredustpoc: USTPOCModel[] = [];

  RecruiterControl = new FormControl();
  filteredrecruiter: RecruiterModel[] = [];

  DellManagerControl = new FormControl();
  filteredDellManager: DellManagerModel[] = [];

  StatusControl = new FormControl();
  filteredStatus: StatusModel[] = [];
  RoledetailsControl = new FormControl()
  filterRoledetails: RoleDetails[] = []
  selectedUSTTPM: any;
  selectedValueacc: any;
  selectedTechnology: any;
  selectedRegion: any;
  selectedLocation: any;
  selectedUstpoc: any;
  selectedRecruiter: any;
  selectedDellManager: any;
  selectedStatus: any;

  isChecked = true;

  Advancedview: boolean = false;
  toppings = new FormControl();

   SelectallColums : boolean=false;
  displayedColumns: string[] = [
    //'isOnHold',
    //'ageing',
    // 'soName',
    'jrCode',
    //'account',
    // 'requestCreationDate',
    // 'onboardingdate',
    'technologyName',
    //'role',
    'roleDetailsName',
    //'region',
    //'location',
    'targetOpenPositions',
    'positionsTobeClosed',
    // 'ustpocName',
    //'recruiterName',
    // 'usttpmName',
    // 'dellManagerName',
    'statusName',
    // 'band',
    // 'projectId',
    // 'accountManager',
    // 'externalResource',
    // 'internalResource',

  ];

  advancedColumns: string[] = [
    'Select All',
    'soName',
    'projectId',
    'ustpocName',
    'usttpmName',
    'requestCreationDate',
    'onboardingdate',
    'recruiterName',
    'dellManagerName',
    'isOnHold',
    'ageing',
    'account',
    'region',
    'band',
    'accountManager',
    'externalResource',
    'internalResource',
    'location',
  ]

  soDataSource: MatTableDataSource<SOModel>;
  @ViewChild('soDataSource') soPaginator: MatPaginator;
  @ViewChild('templateBottomSheet') TemplateBottomSheet: TemplateRef<any>;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  @ViewChild('modalContent') modalContent!: TemplateRef<any>;
  jsonArray: any;

  constructor(
    private excelService: ExcelService,
    private route: Router,
    private service: SoService,
    private regionService: RegionService,
    private locationService: LocationService,
    private accountService: AccountService,
    private tpmService: UstTpmService,
    private pocService: UstPocService,
    private recruiterService: RecruiterService,
    private dellManagerService: DellManagerService,
    private techService: TechnologyService,
    private statusService: StatusService,
    private mappingService: CandidateMappingService,
    public dialog: MatDialog,
    private roledetails: RoledetailsService,
    // private bottomSheet: MatBottomSheet,
    @Inject(LOCALE_ID) public locale: string
  ) { this.maxDate = new Date() }
  ngOnInit(): void {


    this.User = JSON.parse(sessionStorage.getItem("userData") as string);
    this.IsAccessToEdit = this.User.PermissionName === "Edit" ? true : false;

    if (this.IsAccessToEdit) {
      this.displayedColumns.push('actions');
    }

    this.GetSowData();
    this.GetDropdown1();
    this.GetDropdown2();
    this.GetDropdown3();
    this.GetDropdown4();
    this.GetDropdown5();
    this.GetStatusByType();
    this.GetDropdown7();
    this.GetDropdown8();
    this.GetDropdown11();
    this.GetDropdown10();
    this.GetDropdown19()

    this.usttpmControl.valueChanges.subscribe((value) => {
      this.filteredUSTTPM = this.ustTpmList.filter((tpm) =>
        tpm.usttpmName.toLowerCase().includes(value.toLowerCase())
      );
    });


    this.RoledetailsControl.valueChanges.subscribe((value) => {
      this.filterRoledetails = this.roledetailslist.filter((tpm) =>
        tpm.roleDetailsName.toLowerCase().includes(value.toLowerCase())
      );
    });


    this.accountControl.valueChanges.subscribe((value) => {
      this.filteredaccount = this.accountList.filter((account) =>
        account.accountName.toLowerCase().includes(value.toLowerCase())
      )
    });

    this.technologyControl.valueChanges.subscribe((value) => {
      this.filteredtechnology = this.technologyList.filter((technology) =>
        technology.technologyName.toLowerCase().includes(value.toLowerCase())
      )
    });

    this.regionControl.valueChanges.subscribe((value) => {
      this.filteredregion = this.regionList.filter((region) =>
        region.region.toLowerCase().includes(value.toLowerCase())
      )
    });

    this.locationControl.valueChanges.subscribe((value) => {
      this.filteredlocation = this.locationList.filter((location) =>
        location.location.toLowerCase().includes(value.toLowerCase())
      )
    });

    this.USTPOCControl.valueChanges.subscribe((value) => {
      this.filteredustpoc = this.ustPocList.filter((ustpoc) =>
        ustpoc.ustpocName.toLowerCase().includes(value.toLowerCase())
      )
    });

    this.RecruiterControl.valueChanges.subscribe((value) => {
      this.filteredrecruiter = this.recruiterList.filter((recruiter) =>
        recruiter.recruiterName.toLowerCase().includes(value.toLowerCase())
      )
    });

    this.DellManagerControl.valueChanges.subscribe((value) => {
      this.filteredDellManager = this.dellManagerList.filter((dellmanager) =>
        dellmanager.dellManagerName.toLowerCase().includes(value.toLowerCase())
      )
    });

    this.StatusControl.valueChanges.subscribe((value) => {
      this.filteredStatus = this.statusList.filter((status) =>
        status.statusName.toLowerCase().includes(value.toLowerCase())
      )
    });

  }


  onOptionSelected(event: MatAutocompleteSelectedEvent) {
    const selectedValue = event.option.value;
    const usttpmIdControl = this.SowForm.get('usttpmName');
    if (usttpmIdControl) {
      usttpmIdControl.setValue(selectedValue);
    }
    console.log('Selected Value: ', selectedValue);
    this.applyFilter();
  }

  onOptionSelectedacc(event: MatAutocompleteSelectedEvent) {
    const selectedValueacc = event.option.value;
    const accountIdControl = this.SowForm.get('accountName');
    if (accountIdControl) {
      accountIdControl.setValue(selectedValueacc);
    }
    console.log('Selected Value: ', selectedValueacc);
    this.applyFilter();
  }

  onOptionSelectedtech(event: MatAutocompleteSelectedEvent) {
    const selectedTechnology = event.option.value;
    const technologyIdControl = this.SowForm.get('technologyName');
    if (technologyIdControl) {
      technologyIdControl.setValue(selectedTechnology);
    }
    console.log('Selected Value: ', selectedTechnology);
    this.applyFilter();
  }


  onOptionSelectedregion(event: MatAutocompleteSelectedEvent) {
    const selectedRegion = event.option.value;
    const regionIdControl = this.SowForm.get('region');
    if (regionIdControl) {
      regionIdControl.setValue(selectedRegion);
    }
    console.log('Selected Value: ', selectedRegion);
    this.applyFilter();
  }

  onOptionSelectedroledetails(event: MatAutocompleteSelectedEvent) {
    const selectedRoledetails = event.option.value;
    const roledeatailsIdControl = this.SowForm.get('roleDetails');
    if (roledeatailsIdControl) {
      roledeatailsIdControl.setValue(selectedRoledetails);
    }
    console.log('Selected Value: ', selectedRoledetails);
    this.applyFilter();
  }


  onOptionSelectedlocation(event: MatAutocompleteSelectedEvent) {
    const selectedLocation = event.option.value;
    const locationIdControl = this.SowForm.get('location');
    if (locationIdControl) {
      locationIdControl.setValue(selectedLocation);
    }
    console.log('Selected Value: ', selectedLocation);
    this.applyFilter();
  }

  onOptionSelectedustpoc(event: MatAutocompleteSelectedEvent) {
    const selectedUstpoc = event.option.value;
    const ustpocIdControl = this.SowForm.get('ustpocName');
    if (ustpocIdControl) {
      ustpocIdControl.setValue(selectedUstpoc);
    }
    console.log('Selected Value: ', selectedUstpoc);
    this.applyFilter();
  }


  onOptionSelectedrecruiter(event: MatAutocompleteSelectedEvent) {
    const selectedRecruiter = event.option.value;
    const recruiterIdControl = this.SowForm.get('recruiterName');
    if (recruiterIdControl) {
      recruiterIdControl.setValue(selectedRecruiter);
    }
    console.log('Selected Value: ', selectedRecruiter);
    this.applyFilter();
  }

  onOptionSelecteddellManager(event: MatAutocompleteSelectedEvent) {
    const selectedDellManager = event.option.value;
    const dellManagerIdControl = this.SowForm.get('dellManagerName');
    if (dellManagerIdControl) {
      dellManagerIdControl.setValue(selectedDellManager);
    }
    console.log('Selected Value: ', selectedDellManager);
    this.applyFilter();
  }


  onOptionSelectedStatus(event: MatAutocompleteSelectedEvent) {
    const selectedStatus = event.option.value;
    const statusIdControl = this.SowForm.get('statusName');
    if (statusIdControl) {
      statusIdControl.setValue(selectedStatus);
    }
    console.log('Selected Value: ', selectedStatus);
    this.applyFilter();
  }

  exportEmptyExcel() {
    const headers = [
      'DomainName',
      'JRCode',
      'RequestCreationDate',
      'Onboardingdate',
      'AccountName',
      'TechnologyName',
      'Region',
      'Location',
      'TargetOpenPositions',
      'PositionsTobeClosed',
      'USTPOCName',
      'RecruiterName',
      'USTTPMName',
      'DellManagerName',
      'StatusName',
      'Band',
      'ProjectId',
      'AccountManager',
      'ExternalResource',
      'InternalResource',
      'RoleDetails',
      'experienceinyears',
      'Comment'
    ];

    this.excelService.exportEmptyExcelFile('SoTemplateExcel', headers);
  }







  cancelfilter() {
    this.isFormVisible = !this.isFormVisible;
    this.GetSowData();
  }
  toggleFormVisibility() {
    this.isFormVisible = !this.isFormVisible;

  }

  resetAndCloseFilter() {
    this.ClearFilter();
    this.toggleFormVisibility();
  }
  clearSearchInput() {
    this.GetSowData();
  }

  GetSowData() {


    this.service.GetAllSowData().subscribe((data) => {
      console.log(data)

      this.dataSource = new MatTableDataSource(data);
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;


    }
    );

  }



  inputClear(controlNames: string[]) {
    for (const name of controlNames) {
      const control = this.SowForm.get(name);
      if (control) {
        control.reset();
      }
    }
    this.GetSowData();
  }
  ClearFilter() {
    this.SowForm.reset()
    this.applyFilter()
  }


  applyFilter() {
    if (!this.dataSource) {

      return;
    }

    const filterValues = this.SowForm.value as unknown as {
      soName: string | '';
      jrCode: string | null;
      fromDate: Date;
      endDate: Date;
      accountId: string | '';
      accountName: string | null;
      technologyId: string | null;
      technologyName: string | null;
      regionId: string | null;
      region: string | null;
      role: string | null;
      locationId: string | null;
      location: string | null;
      targetOpenPositions: string | null;
      positionsTobeClosed: string | null;
      ustpocId: string | null;
      ustpocName: string | null;
      recruiterId: string | null;
      recruiterName: string | null;
      usttpmId: string | null;
      usttpmName: string | null;
      dellManagerId: string | null;
      dellManagerName: string | null;
      statusId: string | null;
      statusName: string | null;
      band: string | null;
      projectId: string | null;
      accountManager: string | null;
      externalResource: string | null;
      internalResource: string | null;
      fromDate1: Date;
      endDate1: Date;
      onboardingdate: string | null;
      roleDetailsId: number,
      roleDetails: string | null,
      experienceinyears: number,
    };

    this.dataSource.filterPredicate = (item: any) => {
      const compare = (value1: string, value2: string) => {
        return value1.toLowerCase().includes(value2.toLowerCase());
      };

      if (filterValues.soName && !compare(item.soName, filterValues.soName)) {
        return false;
      }

      if (filterValues.jrCode && !compare(item.jrCode, filterValues.jrCode)) {
        return false;
      }
      if (
        filterValues.fromDate && filterValues.endDate && !((new Date(item.requestCreationDate)) >= (new Date(filterValues.fromDate)) && (new Date(item.requestCreationDate)) <= (new Date(filterValues.endDate))) && !(
          (new Date(item.requestCreationDate)) === (new Date(filterValues.fromDate)) &&
          (new Date(item.requestCreationDate)) === (new Date(filterValues.endDate))
        )
      ) {
        return false;
      }

      if (

        filterValues.fromDate1 && filterValues.endDate1 && !((new Date(item.onboardingdate)) >= (new Date(filterValues.fromDate1)) && (new Date(item.onboardingdate)) <= (new Date(filterValues.endDate1))) && !(
          (new Date(item.onboardingdate)) === (new Date(filterValues.fromDate1)) &&
          (new Date(item.onboardingdate)) === (new Date(filterValues.endDate1))

        )
      ) {
        return false;
      }


      if (filterValues.technologyId && item.technologyId !== filterValues.technologyId) {
        return false;
      }
      if (filterValues.technologyName && item.technologyName !== filterValues.technologyName) {
        return false;
      }


      if (filterValues.accountId && item.accountId !== filterValues.accountId) {
        return false;
      }
      if (filterValues.accountName && item.accountName !== filterValues.accountName) {
        return false;
      }

      if (filterValues.regionId && item.regionId !== filterValues.regionId) {
        return false;
      }
      if (filterValues.region && item.region !== filterValues.region) {
        return false;
      }

      if (filterValues.locationId && item.locationId !== filterValues.locationId) {
        return false;
      }
      if (filterValues.location && item.location !== filterValues.location) {
        return false;
      }

      if (filterValues.ustpocId && item.ustpocId !== filterValues.ustpocId) {
        return false;
      }
      if (filterValues.ustpocName && item.ustpocName !== filterValues.ustpocName) {
        return false;
      }


      if (filterValues.recruiterId && item.recruiterId !== filterValues.recruiterId) {
        return false;
      }
      if (filterValues.recruiterName && item.recruiterName !== filterValues.recruiterName) {
        return false;
      }

      if (filterValues.usttpmId && item.usttpmId !== filterValues.usttpmId) {
        return false;
      }
      if (filterValues.usttpmName && item.usttpmName !== filterValues.usttpmName) {
        return false;
      }
      if (filterValues.dellManagerId && item.dellManagerId !== filterValues.dellManagerId) {
        return false;
      }
      if (filterValues.dellManagerName && item.dellManagerName !== filterValues.dellManagerName) {
        return false;
      }

      if (filterValues.statusId && item.statusId !== filterValues.statusId) {
        return false;
      }
      if (filterValues.statusName && item.statusName !== filterValues.statusName) {
        return false;
      }
      if (filterValues.role && !compare(item.role, filterValues.role)) {
        return false;
      }
      if (filterValues.band && !compare(item.band, filterValues.band)) {
        return false;
      }
      if (filterValues.projectId && item.projectId !== filterValues.projectId) {
        return false;
      }

      if (filterValues.accountManager && !compare(item.accountManager, filterValues.accountManager)) {
        return false;
      }

      if (
        filterValues.externalResource &&
        !compare(item.externalResource, filterValues.externalResource)
      ) {
        return false;
      }

      if (
        filterValues.internalResource &&
        !compare(item.internalResource, filterValues.internalResource)
      ) {
        return false;
      }

      return true;
    };
    this.dataSource.filter = 'customFilter';
    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }


  private fb = inject(FormBuilder);
  SowForm = this.fb.group({
    soName: [''],
    jrCode: [null],
    accountId: [null],
    accountName: [null],
    technologyName: [null],
    fromDate: [null],
    endDate: [null],
    technologyId: [null],
    regionId: [null],
    region: [null],
    role: [null],
    locationId: [null],
    location: [null],
    ustpocId: [null],
    ustpocName: [null],
    usttpmName: [null],
    recruiterId: [null],
    recruiterName: [null],
    usttpmId: [null],
    dellManagerId: [null],
    dellManagerName: [null],
    statusId: [null],
    statusName: [null],
    band: [null],
    projectId: [null],
    accountManager: [null],
    externalResource: [null],
    internalResource: [null],
    onboardingdate: [null],
    fromDate1: [null],
    endDate1: [null],
    roleDetailsId: [null],
    roleDetails: [null],
    experienceinyears: [null],
  });


  addfile(event: any) {
    this.file = event.target.files[0];
    let fileReader = new FileReader();
    fileReader.readAsArrayBuffer(this.file);
    fileReader.onload = (e) => {
      this.arrayBuffer = fileReader.result;
      var data = new Uint8Array(this.arrayBuffer);
      var arr = new Array();
      for (var i = 0; i != data.length; ++i)
        arr[i] = String.fromCharCode(data[i]);
      var bstr = arr.join('');
      var workbook = XLSX.read(bstr, { type: 'binary' });
      var first_sheet_name = workbook.SheetNames[0];
      var worksheet = workbook.Sheets[first_sheet_name];
  
      this.filelist = XLSX.utils.sheet_to_json(worksheet, { raw: true });
      
      this.filelist.forEach((element: any) => {
        let elementlist=element;
        if (element.JRCode) {
          // Check if slashes, single quotes, double quotes are present at the start or end
          if (/^['"\\ ]+/.test(element.JRCode) || /['"\\ ]+$/.test(element.JRCode)) {
            element.JRCode = element.JRCode.replace(/['"\\ ]/g, '');
          }
          else{
            element.JRCode=elementlist.JRCode
          }
        }
         element.JRCode=JSON.stringify(element.JRCode)
        console.log(element.ExternalResource)
        console.log(element.ExternalResource=='')
        // if (element.ExternalResource == '') {
        //   this.candidateform.value.pincode = undefined
        // }
  
        const serialNumber1 = element.RequestCreationDate;
        element.RequestCreationDate = new Date(XLSX.SSF.format('yyyy-mm-dd', serialNumber1));

        const serialNumber2 = element.Onboardingdate;
        element.Onboardingdate = new Date(XLSX.SSF.format('yyyy-mm-dd', serialNumber2));
      });
  
      console.log(this.filelist);
      this.service.PostSOWDuplicateCheck(this.filelist).subscribe((x) => {
        alert(x);
        
        event.target.value = '';
        this.GetSowData();
      }, err =>
      console.log(err)
        //event.target.value = ''
      );
    };
  }
  


  DownloadExcel() {
    const filteredData = this.dataSource.filteredData;
    if (filteredData.length > 0) {
      const headers = [
        'DomainName',
        'JRCode',
        'RequestCreationDate',
        'Onboardingdate',
        'AccountName',
        'TechnologyName',
        'Region',
        'Location',
        'TargetOpenPositions',
        'PositionsTobeClosed',
        'USTPOCName',
        'RecruiterName',
        'USTTPMName',
        'DellManagerName',
        'StatusName',
        'Band',
        'ProjectId',
        'AccountManager',
        'ExternalResource',
        'InternalResource',
        'RoleDetails',
        'experienceinyears',
        'Comment'
      ];

      const downloadData = filteredData.map((data) => ({
        'DomainName': data.soName,
        'JRCode': data.jrCode,
        //'RequestCreationDate': data.requestCreationDate,
        'RequestCreationDate': (data.requestCreationDate==='1900-01-01T00:00:00'?null:data.requestCreationDate),
        //'Onboardingdate': data.onboardingdate,

        'Onboardingdate': (data.onboardingdate==='1900-01-01T00:00:00'?null:data.onboardingdate),
        AccountName: data.accountName,
        TechnologyName: data.technologyName,

        Region: data.region,
        Location: data.location,
        'TargetOpenPositions': data.targetOpenPositions,
        'PositionsTobeClosed': data.positionsTobeClosed,
        'USTPOCName': data.ustpocName,
        RecruiterName: data.recruiterName,
        'USTTPMName': data.usttpmName,
        'DellManagerName': data.dellManagerName,
        StatusName: data.statusName,
        //Band: data.band,
        Band: (data.band==='<<<No Data>>>'?null:data.band),
        //'ProjectId': data.projectId,
        'ProjectId': (data.projectId==='<<<No Data>>>'?null:data.projectId),
        //'AccountManager': data.accountManager,
        'AccountManager': (data.accountManager==='<<<No Data>>>'?null:data.accountManager),

        //'ExternalResource': data.externalResource,
        'ExternalResource': (data.externalResource==='<<<No Data>>>'?null:data.externalResource),


        //'InternalResource': data.internalResource,
        'InternalResource': (data.internalResource==='<<<No Data>>>'?null:data.internalResource),


        'RoleDetails': data.roleDetails,
        'experienceinyears': data.experienceinyears,
        Comments: (data.role==='<<<No Data>>>'?null:data.role)
        

      }));

      this.excelService.jsonExportAsExcel(downloadData, 'SO Details', headers);
    } else {
      alert('No Records found!');
    }
  }
  GetDropdown19() {
    return new Promise((res, rej) => {
      this.roledetails.GetAllRoledetailsData().subscribe((result) => {
        this.roledetailslist = result;
        console.log(this.roledetailslist)
        res('')
      })
    })
  }
  updateSODetails(row: SOModel): void {
    row.isEditing = !row.isEditing;
  }

  isSelectAllChecked: boolean = false;
  updatedcontroller: string[] = [];
 
  onOptionClick(column: string, matSelectRef: MatSelect): void {
    if (column === 'Select All') {
      this.handleAdvancedViewChange();
      matSelectRef.close();
    } else {
      this.AddColumns(column);
    }
    console.log(this.displayedColumns.length)
    console.log(this.displayedColumns)
  }
 
  handleAdvancedViewChange() {
 
    if (this.isSelectAllChecked == false) {
      this.updatedcontroller=[];
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
      const projectIdIndex = this.displayedColumns.indexOf('statusName');
      if (projectIdIndex !== -1) {
        this.displayedColumns.splice(projectIdIndex + 1, 0, columnname);
      }
    }
    else {
      if (Index !== -1) {
        this.displayedColumns.splice(Index, 1);
      }
    }
 
    if (this.displayedColumns.length == 24) {
      this.updatedcontroller=[];
      this.updatedcontroller = this.toppings.value.filter((column: any) => column !== 'Select All');
      this.updatedcontroller.push('Select All')
      this.toppings.setValue(this.updatedcontroller);
 
      console.log(this.updatedcontroller)
 
      this.isSelectAllChecked = true;
    }
    else {
      this.updatedcontroller=[];
      this.updatedcontroller = this.toppings.value.filter((column: any) => column !== 'Select All');
 
      this.toppings.setValue(this.updatedcontroller);
      this.isSelectAllChecked = false;
    }
 
  }
 

  onToggleChange(event: MatSlideToggleChange, row: any): void {
    row.isOnHold = event.checked;

  }



  saveSODetails(row: any): void {
    row.requestCreationDate = this.formatdate(row.requestCreationDate) + "T00:00:00.00Z",
      row.onboardingdate = this.formatdate(row.onboardingdate) + "T00:00:00.00Z",
      row.type = 'update',
      console.log(row)

    this.service.UpdateSowData(row.sowId, row).subscribe(
      (response) => {

        row.isEditing = false;

        this.GetSowData();
      },
      (error) => {
        console.error('Error updating SOW data', error);
      }
    );
  }

  cancelEdit(row: any): void {
    row.isEditing = false;
    this.GetSowData();
  }

  deleteDetails(data: any) {
    this.Id = data.sowId;
    var obj: any = null;
    var decision = confirm('Are you sure you want to delete?');
    if (decision) {
      this.mappinglst.find((x: any) => {
        if (x.sowId == this.Id) {
          obj = x;
        }
      });
      if (obj == null) {
        this.service.DeleteSowData(data.sowId).subscribe((res) => {
          alert(res);
          this.GetSowData();
          this.Id = null;
        });
      } else {
        alert(
          'Mapping Exists for this SO with candidate.' +
          '\n' +
          'Please unmap and then delete'
        );
      }
    } else {
      alert('Data not deleted');
    }
  }

  GetDropdown1() {
    return new Promise((res, rej) => {
      this.accountService.GetAllAccountData().subscribe((result) => {
        this.accountList = result;
        res('');
      });
    });
  }

  GetDropdown2() {
    return new Promise((res, rej) => {
      this.techService.GetAllTechData().subscribe((result) => {
        this.technologyList = result;
        res('');
      });
    });
  }

  GetDropdown3() {
    return new Promise((res, rej) => {
      this.recruiterService.GetAllRecruiterData().subscribe((result) => {
        this.recruiterList = result;
        res('');
      });
    });
  }

  GetDropdown4() {
    return new Promise((res, rej) => {
      this.pocService.GetAllUstPocData().subscribe((result) => {
        this.ustPocList = result;
        res('');
      });
    });
  }

  GetDropdown5() {
    return new Promise((res, rej) => {
      this.dellManagerService.GetAllDellManagerData().subscribe((result) => {
        this.dellManagerList = result;
        res('');
      });
    });
  }

  getStatus() {
    return new Promise((res, rej) => {
      this.statusService.GetAllStatusData().subscribe((result) => {
        this.statusList = result;
        res('');
      });
    });
  }

  GetStatusByType() {
    return new Promise((res, rej) => {
      this.statusService.GetStatusByType('so').subscribe((result) => {
        this.statusList = result;
        res('');
      });
    });
  }

  GetDropdown7() {
    return new Promise((res, rej) => {
      this.regionService.GetAllRegionData().subscribe((result) => {
        this.regionList = result;
        console.log(result)
        res('');
      });
    });
  }

  GetDropdown8() {
    return new Promise((res) => {
      this.tpmService.GetAllUSTTPMData().subscribe((result) => {
        this.ustTpmList = result;
        res('');
      });
    });
  }

  onRegionSelected(regionId: string): void {
    this.selectedRegionId = regionId;

    this.GetDropdown9(regionId);
    this.isRegionSelected = true;
  }

  GetDropdown9(id: any) {
    console.log(id)
    return new Promise((res, rej) => {
      this.locationService.GetLocationByRegionId(id).subscribe((result) => {
        this.locationList = result;

        res('');
      });
    });
  }
  GetDropdown11() {
    return new Promise((res, rej) => {
      this.locationService.GetAllLocationData().subscribe((result) => {
        this.locationList = result;

        res('');
      });
    });
  }
  GetDropdown10() {
    return new Promise((res, rej) => {
      this.mappingService.GetAllCandidateMappingData().subscribe((result) => {
        this.mappinglst = result;
        res('');
      });
    });
  }

  openDialog(row: any) {
    let sowid = row.sowId
    console.log(sowid)
    sessionStorage.setItem("sowid", sowid)
    const dialogRef = this.dialog.open(ScreeningComponent);

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }

  getbyjd(row: any) { 
    let sowid = row.sowId
    console.log(sowid)
    sessionStorage.setItem("sowid", sowid)
    if (sowid) {
      this.service.GetSowById(sowid).subscribe((r) => {
        this.jobdescdata = r;
        const dialogRef = this.dialog.open(this.modalContent);

        console.log(this.jobdescdata)
        
        this.JobDescription=this.jobdescdata[0].jobDesc.split("\n\u2022 ")
        console.log(this.JobDescription);
      })
    }
    console.log(this.jobdescdata)
    //const dialogRef = this.dialog.open(this.modalContent);

    // this.bottomSheet.dismiss();

  }


  formatdate(date: any) {
    return formatDate(date, 'yyyy-MM-dd', this.locale)
  }




  inputDate: any;
  inputDate1: any;

  addfile_BillingData(event: any) {
    this.file = event.target.files[0];
    let fileReader = new FileReader();
    fileReader.readAsArrayBuffer(this.file);
    fileReader.onload = (e) => {
      this.arrayBuffer = fileReader.result;
      var data = new Uint8Array(this.arrayBuffer);
      var arr = new Array();
      for (var i = 0; i != data.length; ++i)
        arr[i] = String.fromCharCode(data[i]);
      var bstr = arr.join('');
      var workbook = XLSX.read(bstr, { type: 'binary' });
      var first_sheet_name = workbook.SheetNames[0];
      var worksheet = workbook.Sheets[first_sheet_name];

      this.filelist = XLSX.utils.sheet_to_json(worksheet, { raw: true });
      console.log(this.filelist)
      console.log(this.filelist.length)
      // for (var i = 0; i < this.filelist.length; i++) {
      //   if(typeof (this.filelist[i].USTTPMUID)!='string')
      //   {
      //     this.filelist[i].USTTPMUID = JSON.stringify(this.filelist[i].USTTPMUID)

      //     console.log(this.filelist[i].USTTPMUID)
      //   }
      //   // else{
      //   //   console.log(this.filelist[i].USTTPMId)
      //   // }



      // }

      console.log(this.filelist)
      this.service.PostSOWDATA_UPloadToDB(this.filelist).subscribe((x) => {
        alert(x);
        event.target.value = '';
        this.GetSowData()
      }, (error) => {
        console.log(error)
      }
      );

    };



  }

  ExcelDateToJSDate(serial: any) {

    // Assuming that the Excel date is in UTC timezone
    var utc_days = Math.floor(serial - 25569);
    var utc_value = utc_days * 86400;
    var date_info = new Date(utc_value * 1000);

    var fractional_day = serial - Math.floor(serial) + 0.0000001;

    var total_seconds = Math.floor(86400 * fractional_day);

    var seconds = total_seconds % 60;

    total_seconds -= seconds;

    var hours = Math.floor(total_seconds / (60 * 60));
    var minutes = Math.floor(total_seconds / 60) % 60;

    // Adjust the date to the desired timezone (e.g., UTC+0)
    var adjustedDate = new Date(Date.UTC(date_info.getUTCFullYear(), date_info.getUTCMonth(), date_info.getUTCDate(), hours, minutes, seconds));

    return adjustedDate;
  }

























  addfile_Data(event: any) {

    this.file = event.target.files[0];
    let fileReader = new FileReader();
    fileReader.readAsArrayBuffer(this.file);
    fileReader.onload = (e) => {
      this.arrayBuffer = fileReader.result;
      var data = new Uint8Array(this.arrayBuffer);
      var arr = new Array();
      for (var i = 0; i != data.length; ++i)
        arr[i] = String.fromCharCode(data[i]);
      var bstr = arr.join('');
      var workbook = XLSX.read(bstr, { type: 'binary' });
      var first_sheet_name = workbook.SheetNames[4];
      var worksheet = workbook.Sheets[first_sheet_name];

      this.filelist1 = XLSX.utils.sheet_to_json(worksheet, { raw: true });
      this.filelist = XLSX.utils.sheet_to_json(worksheet, { raw: true });
      for (var i = 0; i < this.filelist1.length; i++) {
        this.filelist[i].JR = JSON.stringify(this.filelist1[i].JR)

        if (this.filelist1[i].OnboardingDate != undefined) {
          const serialNumber1 = this.filelist1[i].OnboardingDate;
          this.inputDate1 = new Date(XLSX.SSF.format('yyyy-mm-dd', serialNumber1));
        }


        this.filelist[i].OnboardingDate = this.filelist1[i].OnboardingDate == undefined ? null : this.inputDate1

        if (this.filelist1[i].ReqCreationDate != undefined) {
          const serialNumber = this.filelist1[i].ReqCreationDate;
          this.inputDate = new Date(XLSX.SSF.format('yyyy-mm-dd', serialNumber));
        }


        this.filelist[i].ReqCreationDate = this.filelist1[i].ReqCreationDate == undefined ? null : this.inputDate


        this.filelist[i].PositionsTobeClosed = JSON.stringify(this.filelist1[i].PositionsTobeClosed)
        this.filelist[i].Domain = this.filelist1[i].Domain == undefined ? "NP" : this.filelist1[i].Domain
        this.filelist[i].Region = this.filelist1[i].Region == undefined ? "NP" : this.filelist1[i].Region
        this.filelist[i].Account = this.filelist1[i].Account == undefined ? "NP" : this.filelist1[i].Account
        this.filelist[i].Technology = this.filelist1[i].Technology == undefined ? "NP" : this.filelist1[i].Technology
        this.filelist[i].Role = this.filelist1[i].Role == undefined ? "NP" : this.filelist1[i].Role
        this.filelist[i].Location = this.filelist1[i].Location == undefined ? "NP" : this.filelist1[i].Location
        this.filelist[i].TargetOpenPositions = this.filelist1[i].TargetOpenPositions == undefined ? "NP" : JSON.stringify(this.filelist1[i].TargetOpenPositions)
        this.filelist[i].PositionsTobeClosed = this.filelist1[i].PositionsTobeClosed == undefined ? "NP" : JSON.stringify(this.filelist1[i].PositionsTobeClosed)
        this.filelist[i].USTPOC = this.filelist1[i].USTPOC == undefined ? "NP" : this.filelist1[i].USTPOC

        this.filelist[i].Recruiter = this.filelist1[i].Recruiter == undefined ? "NP" : this.filelist1[i].Recruiter
        this.filelist[i].USTTPM = this.filelist1[i].USTTPM == undefined ? "NP" : this.filelist1[i].USTTPM
        this.filelist[i].DellManager = this.filelist1[i].DellManager == undefined ? "NP" : this.filelist1[i].DellManager
        this.filelist[i].Status = this.filelist1[i].Status == undefined ? "NP" : this.filelist1[i].Status
        this.filelist[i].Band = this.filelist1[i].Band == undefined ? "NP" : this.filelist1[i].Band
        this.filelist[i].ProjectID = this.filelist1[i].ProjectID == undefined ? "NP" : this.filelist1[i].ProjectID

        this.filelist[i].AM = this.filelist1[i].AM == undefined ? "NP" : this.filelist1[i].AM


        this.filelist[i].InternalResource = this.filelist1[i].InternalResource == undefined ? "NP" : JSON.stringify(this.filelist1[i].InternalResource)

        this.filelist[i].ExternalResource = this.filelist1[i].ExternalResource == undefined ? "NP" : this.filelist1[i].ExternalResource

        this.filelist[i].ReqCreationDateold = ""




      }



      console.log(this.filelist)
      this.service.PostSOWDATA_UPloadToDB(this.filelist).subscribe((x) => {
        alert(x);
        event.target.value = '';
        this.GetSowData()
      }, err =>

        event.target.value = ''
      );

    };
  }



}