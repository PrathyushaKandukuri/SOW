import { AfterViewInit, Component, Inject, LOCALE_ID, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { ScreeningService } from '../../shared/Services/ScreeningService/screening.service';
import { ScreeningModel } from '../../Models/ScreeningModel';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatDialog } from '@angular/material/dialog';
import * as moment from 'moment';
import { SoService } from 'src/app/shared/Services/SoService/so.service';


@Component({
  selector: 'app-screening',
  templateUrl: './screening.component.html',
  styleUrls: ['./screening.component.css']
})
export class ScreeningComponent implements OnInit {
  panelOpenState = false;
  totalScreeningData: any;
  SelectedScreeningProfiles: ScreeningModel[] = [];
  RejectedScreeningProfiles: ScreeningModel[] = [];
  Onholdprofiles: ScreeningModel[] = [];

  SelectedL1Profiles: ScreeningModel[] = [];
  RejectedL1Profiles: ScreeningModel[] = [];

  SelectedL2Profiles: ScreeningModel[] = [];
  RejectedL2Profiles: ScreeningModel[] = [];
  dataLoaded: boolean = false;
  showInput: boolean = false;
  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;
  thirdFormGroup: FormGroup;
  L1OnHold: ScreeningModel[] = [];
  L2OnHold: ScreeningModel[] = [];
  InProgress:ScreeningModel[]=[]
  OfferAccepted: ScreeningModel[] = [];
  OfferDeclined: ScreeningModel[] = [];
  TotalProfiles: ScreeningModel[] = [];
  TotalProfilesDataSource: MatTableDataSource<any>
  OfferAccepteddataSource: MatTableDataSource<any>;
  OfferDeclineddataSource: MatTableDataSource<any>;
  SowId: number = 0;
  SoData: any;
  mainTableData: any = [];

  mainTabledataSource: MatTableDataSource<any>;


  OnholddataSource: MatTableDataSource<any>;
  ScreeningSelecteddataSource: MatTableDataSource<any>;
  ScreeningRejecteddataSource: MatTableDataSource<any>;

  L1SelecteddataSource: MatTableDataSource<any>;
  L1RejecteddataSource: MatTableDataSource<any>;
  L2SelecteddataSource: MatTableDataSource<any>;
  L2RejecteddataSource: MatTableDataSource<any>;
  L1OnHolddataSource: MatTableDataSource<any>;
  L2OnHolddataSource: MatTableDataSource<any>;
  InProgressdataSource:MatTableDataSource<any>;
  dataSource3: MatTableDataSource<any>;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild('modalPopUpForScreeningSelected') modalContentForScreeningSelected!: TemplateRef<any>;
  @ViewChild('modalPopUpForScreeningRejected') modalContentForScreeningRejected!: TemplateRef<any>;
  @ViewChild('modalPopUpForL1Selected') modalContentForL1Selected!: TemplateRef<any>;
  @ViewChild('modalPopUpForL1Rejected') modalContentForL1Rejected!: TemplateRef<any>;

  @ViewChild('modalPopUpForL2Selected') modalContentForL2Selected!: TemplateRef<any>;
  @ViewChild('modalPopUpForL2Rejected') modalContentForL2Rejected!: TemplateRef<any>;

  @ViewChild('modalPopUpForOfferAccepted') modalPopUpForOfferAccepted!: TemplateRef<any>;
  @ViewChild('modalPopUpForOfferDeclined') modalPopUpForOfferDeclined!: TemplateRef<any>;
  @ViewChild('modalPopUpForTotalProfilesTagged') modalPopUpForTotalProfilesTagged!: TemplateRef<any>;
  @ViewChild('modalL1OnHold') modalL1OnHold!: TemplateRef<any>;
  @ViewChild('modalL2OnHold') modalL2OnHold!: TemplateRef<any>;
@ViewChild('modalInProgress') modalInProgress!:TemplateRef<any>
  displayedColumns = ['CandidateUID', 'CandidateName', 'OnBoardingDate'];
  maxDate: Date;
  selectedOption: string = 'Default';
  fromDate: Date | undefined = undefined;
  endDate: Date | undefined = undefined;


  constructor(private screeningservice: ScreeningService, private service: SoService, private _formBuilder: FormBuilder, private dialog: MatDialog,
    @Inject(LOCALE_ID) public locale: string) { this.maxDate = new Date() }

  ngOnInit(): void {

    this.firstFormGroup = this._formBuilder.group({
      firstCtrl: ['']
    });
    this.secondFormGroup = this._formBuilder.group({
      secondCtrl: ['']
    });
    this.thirdFormGroup = this._formBuilder.group({
      thirdCtrl: ['']
    });
    let sowid = parseInt(sessionStorage.getItem("sowid") as string);
    console.log(sowid)
    this.SowId = sowid;


    this.service.GetSowById(this.SowId).subscribe((r) => {
      this.SoData = r;
      console.log(this.SoData)

    })



    this.onSelectionChange();


  }
  onDatePickerClosed() {
    console.log(this.fromDate);
    console.log(this.endDate);
    this.selectedOption = 'CustomizedDate';
    this.onSelectionChange();


  }

  onSelectionChange() {
    let startdate: any;
    let enddate: any;

    switch (this.selectedOption) {
      case 'Default':
        startdate = moment().subtract(10, 'years').calendar();
        enddate = moment().add(10, 'years').calendar();

        break;
      case 'Weekly':
        startdate = moment().subtract(7, 'days').calendar();
        enddate = moment().format('MM/DD/YYYY');

        break;
      case 'Fortnight':
        startdate = moment().subtract(15, 'days').calendar();
        enddate = moment().format('MM/DD/YYYY');

        break;
      case 'Monthly':
        startdate = moment().subtract(30, 'days').calendar();
        enddate = moment().format('MM/DD/YYYY');


        break;
      case 'CustomizedDate':
        startdate = moment(this.fromDate).format("MM/DD/YYYY");
        enddate = moment(this.endDate).format('MM/DD/YYYY');


        break;


    }
    this.fromDate = startdate;
    this.endDate = enddate;
    console.log(this.fromDate)
    console.log(this.endDate)
    this.screeningservice.GetScreeningDataByID(this.SowId, this.fromDate, this.endDate).subscribe((result) => {

      this.totalScreeningData = result;
      console.log(this.totalScreeningData)
      this.dataLoaded = true;


    })
  }
  clearDates() {
    this.fromDate = undefined;
    this.endDate = undefined;
  }
  change(date: any) {
    console.log(date)
  }

  onDatePickerOpened() {
    console.log('Datepicker opened');
  }
  applyFilterScreeningSelected(filterValue: string) {
    filterValue = filterValue.trim();
    filterValue = filterValue.toLowerCase();
    this.ScreeningSelecteddataSource.filter = filterValue;
  }
  applyFilterScreeningRejected(filterValue: string) {
    filterValue = filterValue.trim();
    filterValue = filterValue.toLowerCase();
    this.ScreeningRejecteddataSource.filter = filterValue;
  }

  applyFilterTotalProfiles(filterValue: string) {
    filterValue = filterValue.trim();
    filterValue = filterValue.toLowerCase();
    this.TotalProfilesDataSource.filter = filterValue;
  }

  applyFilterOfferAccepted(filterValue: string) {
    filterValue = filterValue.trim();
    filterValue = filterValue.toLowerCase();
    this.OfferAccepteddataSource.filter = filterValue;
  }


  applyFilterOfferRejected(filterValue: string) {
    filterValue = filterValue.trim();
    filterValue = filterValue.toLowerCase();
    this.OfferDeclineddataSource.filter = filterValue;
  }

  applyFilterL1Selected(filterValue: string) {
    filterValue = filterValue.trim();
    filterValue = filterValue.toLowerCase();
    this.L1SelecteddataSource.filter = filterValue;
  }
  applyFilterL1Rejected(filterValue: string) {
    filterValue = filterValue.trim();
    filterValue = filterValue.toLowerCase();
    this.L1RejecteddataSource.filter = filterValue;
  }

  applyFilterL2Selected(filterValue: string) {
    filterValue = filterValue.trim();
    filterValue = filterValue.toLowerCase();
    this.L2SelecteddataSource.filter = filterValue;
  }
  applyFilterL2Rejected(filterValue: string) {
    filterValue = filterValue.trim();
    filterValue = filterValue.toLowerCase();
    this.L2RejecteddataSource.filter = filterValue;
  }

  applyFilterL1OnHold(filterValue: string) {
    filterValue = filterValue.trim();
    filterValue = filterValue.toLowerCase();
    this.L1OnHolddataSource.filter = filterValue;
  }
  applyFilterL2OnHold(filterValue: string) {
    filterValue = filterValue.trim();
    filterValue = filterValue.toLowerCase();
    this.L2OnHolddataSource.filter = filterValue;
  }

  applyFilterInprogress(filterValue: string) {
    filterValue = filterValue.trim();
    filterValue = filterValue.toLowerCase();
    this.InProgressdataSource.filter = filterValue;
  }



  PopUpForScreeningSelected() {

    let obj = {
      'type': 'SelectedCandidatesinScreening',
      'sowid': this.SowId
    }

    this.screeningservice.GetProfilesBySo(obj, this.fromDate, this.endDate).subscribe((result) => {
      console.log(result);
      this.SelectedScreeningProfiles = result
      this.ScreeningSelecteddataSource = new MatTableDataSource(this.SelectedScreeningProfiles);
      this.ScreeningSelecteddataSource.paginator = this.paginator;
      this.ScreeningSelecteddataSource.sort = this.sort;
    })
    const dialogRef = this.dialog.open(this.modalContentForScreeningSelected);

  }
  PopUpForScreeningRejected() {
    let obj = {
      'type': 'RejectedCandidatesinScreening',
      'sowid': this.SowId
    }

    this.screeningservice.GetProfilesBySo(obj, this.fromDate, this.endDate).subscribe((result) => {
      console.log(result);
      this.RejectedScreeningProfiles = result
      this.ScreeningRejecteddataSource = new MatTableDataSource(this.RejectedScreeningProfiles);
      this.ScreeningRejecteddataSource.paginator = this.paginator;
      this.ScreeningRejecteddataSource.sort = this.sort;
    })
    const dialogRef = this.dialog.open(this.modalContentForScreeningRejected);

  }
  PopUpForL1Selected() {

    let obj = {
      'type': 'SelectedCandidatesinL1',
      'sowid': this.SowId
    }

    this.screeningservice.GetProfilesBySo(obj, this.fromDate, this.endDate).subscribe((result) => {
      console.log(result);
      this.SelectedL1Profiles = result
      this.L1SelecteddataSource = new MatTableDataSource(this.SelectedL1Profiles);
      this.L1SelecteddataSource.paginator = this.paginator;
      this.L1SelecteddataSource.sort = this.sort;
    })

    const dialogRef = this.dialog.open(this.modalContentForL1Selected);

  }


  PopUpForL1Rejected() {

    let obj = {
      'type': 'RejectedCandidatesinL1',
      'sowid': this.SowId
    }

    this.screeningservice.GetProfilesBySo(obj, this.fromDate, this.endDate).subscribe((result) => {
      console.log(result);
      this.RejectedL1Profiles = result
      this.L1RejecteddataSource = new MatTableDataSource(this.RejectedL1Profiles);
      this.L1RejecteddataSource.paginator = this.paginator;
      this.L1RejecteddataSource.sort = this.sort;
    })


    const dialogRef = this.dialog.open(this.modalContentForL1Rejected);
  }
  PopUpForL2Selected() {
    let obj = {
      'type': 'SelectedCandidatesinL2',
      'sowid': this.SowId
    }

    this.screeningservice.GetProfilesBySo(obj, this.fromDate, this.endDate).subscribe((result) => {
      console.log(result);
      this.SelectedL2Profiles = result
      this.L2SelecteddataSource = new MatTableDataSource(this.SelectedL2Profiles);
      this.L2SelecteddataSource.paginator = this.paginator;
      this.L2SelecteddataSource.sort = this.sort;
    })

    const dialogRef = this.dialog.open(this.modalContentForL2Selected);

  }

  PopUpForL2Rejected() {

    let obj = {
      'type': 'RejectedCandidatesinL2',
      'sowid': this.SowId
    }

    this.screeningservice.GetProfilesBySo(obj, this.fromDate, this.endDate).subscribe((result) => {
      console.log(result);
      this.RejectedL2Profiles = result
      this.L2RejecteddataSource = new MatTableDataSource(this.RejectedL2Profiles);
      this.L2RejecteddataSource.paginator = this.paginator;
      this.L2RejecteddataSource.sort = this.sort;
    })

    const dialogRef = this.dialog.open(this.modalContentForL2Rejected);
  }

  PopUpForofferAccepted() {
    let obj = {
      'type': 'OfferAccepted',
      'sowid': this.SowId
    }

    this.screeningservice.GetProfilesBySo(obj, this.fromDate, this.endDate).subscribe((result) => {
      console.log(result);
      this.OfferAccepted = result
      this.OfferAccepteddataSource = new MatTableDataSource(this.OfferAccepted);
      this.OfferAccepteddataSource.paginator = this.paginator;
      this.OfferAccepteddataSource.sort = this.sort;
    })

    const dialogRef = this.dialog.open(this.modalPopUpForOfferAccepted);

  }

  PopUpForofferRejected() {
    let obj = {
      'type': 'OfferDeclined',
      'sowid': this.SowId
    }

    this.screeningservice.GetProfilesBySo(obj, this.fromDate, this.endDate).subscribe((result) => {
      console.log(result);
      this.OfferDeclined = result
      this.OfferDeclineddataSource = new MatTableDataSource(this.OfferDeclined);
      this.OfferDeclineddataSource.paginator = this.paginator;
      this.OfferDeclineddataSource.sort = this.sort;
    })

    const dialogRef = this.dialog.open(this.modalPopUpForOfferDeclined);

  }

  PopUpForTotalProfiles() {
    let obj = {
      'type': 'Totalprofiles',
      'sowid': this.SowId
    }

    this.screeningservice.GetProfilesBySo(obj, this.fromDate, this.endDate).subscribe((result) => {
      console.log(result);
      this.TotalProfiles = result
      this.TotalProfilesDataSource = new MatTableDataSource(this.TotalProfiles);
      this.TotalProfilesDataSource.paginator = this.paginator;
      this.TotalProfilesDataSource.sort = this.sort;
    })

    const dialogRef = this.dialog.open(this.modalPopUpForTotalProfilesTagged);

  }


  PopUpForL1Onhold() {
    let obj = {
      'type': 'L1onhold',
      'sowid': this.SowId
    }

    this.screeningservice.GetProfilesBySo(obj, this.fromDate, this.endDate).subscribe((result) => {
      console.log("hi", result);
      this.L1OnHold = result
      this.L1OnHolddataSource = new MatTableDataSource(this.L1OnHold);
      this.L1OnHolddataSource.paginator = this.paginator;
      this.L1OnHolddataSource.sort = this.sort;
    })

    const dialogRef = this.dialog.open(this.modalL1OnHold);

  }

  PopUpForL2OnHold() {
    let obj = {
      'type': 'L2onhold',
      'sowid': this.SowId
    }

    this.screeningservice.GetProfilesBySo(obj, this.fromDate, this.endDate).subscribe((result) => {
      console.log(result);
      this.L2OnHold = result
      this.L2OnHolddataSource = new MatTableDataSource(this.L2OnHold);
      this.L2OnHolddataSource.paginator = this.paginator;
      this.L2OnHolddataSource.sort = this.sort;
    })

    const dialogRef = this.dialog.open(this.modalL2OnHold);

  }

  PopUpForInProgress() {
    let obj = {
      'type': 'InProgress',
      'sowid': this.SowId
    }

    this.screeningservice.GetProfilesBySo(obj, this.fromDate, this.endDate).subscribe((result) => {
      console.log(result);
      this.InProgress = result
      this.InProgressdataSource = new MatTableDataSource(this.InProgress);
      this.InProgressdataSource.paginator = this.paginator;
      this.InProgressdataSource.sort = this.sort;
    })

    const dialogRef = this.dialog.open(this.modalInProgress);

  }



}



