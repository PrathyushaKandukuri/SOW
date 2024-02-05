import { formatDate } from '@angular/common';
import { Component, Inject, LOCALE_ID, inject } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormGroupDirective, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { cloneWith } from 'lodash';
import { CandidateService } from 'src/app/shared/Services/CandidateService/candidate.service';
import { StatusService } from 'src/app/shared/Services/StatusService/status.service';

@Component({
  selector: 'app-candidate-list',
  templateUrl: './candidate-list.component.html',
  styleUrls: ['./candidate-list.component.css']
})
export class CandidateListComponent {
  statusList: any;
  isAuthor: boolean = false;

  maxDate: Date;
  constructor(private _candidateService: CandidateService,
    @Inject(LOCALE_ID) public locale: string,
    // private _router: ActivatedRoute,
    // private commonServ: CommonService,
    private _route: Router,
    private _statusService: StatusService,
    private snackBar: MatSnackBar
  ) {


    this.maxDate = new Date()
  }
  image: any
  warning: any
  selected = navigator.language;
  file:any;

  candidateform = new FormGroup({
    candidateName: new FormControl('', [Validators.required]),
    candidateUid: new FormControl('', [Validators.required]),
    dob: new FormControl(''),
    mobileNo: new FormControl('', [Validators.pattern("^[0-9]*$"), Validators.minLength(10), Validators.maxLength(10)]),
    email: new FormControl('', [Validators.required, Validators.email]),
    gender: new FormControl('male', [Validators.required]),
    status: new FormControl('', [Validators.required]),
    joiningDate: new FormControl(''),
    skills: new FormControl('', [Validators.required]),
    location: new FormControl('', [Validators.required]),
    address: new FormControl(''),
    pincode: new FormControl('', [Validators.minLength(6), Validators.maxLength(6), Validators.pattern("^[0-9]*$")]),
    isInternal: new FormControl<Boolean>(false),
    pan:new FormControl(''),
    panNumber: new FormControl('',[Validators.maxLength(10),Validators.minLength(10),Validators.pattern("^[A-Z]{5}[0-9]{4}[A-Z]{1}"),Validators.required])
    
  })

  ngOnInit(): void {
    this.isAuthor = JSON.parse(sessionStorage.getItem("author") as string);

    this.GetStatusByType();

  }
    onImageSelected(event: any) {
      this.file = event.target.files[0];

    
      const reader = new FileReader();
      reader.readAsDataURL(this.file);
      reader.onload = () => {
        const base64Image = reader.result!.toString();
      
        this.image = base64Image
      console.log(this.image)

        // save the base64Image in a variable or pass it to a service for further processing
      };
    }
  GetStatusByType() {
    this._statusService.GetStatusByType('Candidate').subscribe(result => {
      this.statusList = result;
    })
  }
  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 2000,
      panelClass:['red-snackbar']
    });
  }

  onSubmit(formDirective: FormGroupDirective): void {
    debugger
    const candidateControl = this.candidateform.get('isInternal');
    if(candidateControl?.value===null)
    {
      candidateControl.setValue(false);
    }
    if (candidateControl) {

      candidateControl.markAsTouched;
    }
    console.log(candidateControl);
    console.log(this.candidateform.value);

    if (this.candidateform.valid) {
      console.log(this.candidateform.value.joiningDate == "" )
      if (this.candidateform.value.dob == '') {
        this.candidateform.value.dob = undefined
      }
      else {
        this.candidateform.value.dob = formatDate(this.candidateform.value.dob as string, 'yyyy-MM-dd', this.locale);

      }
      if (this.candidateform.value.joiningDate == '') {
        this.candidateform.value.joiningDate = undefined
      }
      else {
        this.candidateform.value.joiningDate = formatDate(this.candidateform.value.joiningDate as string, 'yyyy-MM-dd', this.locale);

      }

      if (this.candidateform.value.pincode == '') {
        this.candidateform.value.pincode = undefined
      }
       
      if (this.candidateform.value.address == '') {
        this.candidateform.value.address = undefined
      }
      if(this.image!='')
      {
        this.candidateform.value.pan=this.image
      }

      this._candidateService.PostCandidateData(this.candidateform.value).subscribe(data => {
      //  this.openSnackBar(data,'')
      alert(data)
        formDirective.resetForm();
        this.candidateform.reset();
        this.file.reset()
        
        // this.candidateform.markAsUntouched()
        // this.markAllFieldsAsUntouched();

      },
        err =>
          console.log(err))
    }
    else {
      this.openSnackBar("All Fields are mandatory",'ok')

    }
  }

  markAllFieldsAsUntouched() {
    Object.keys(this.candidateform.controls).forEach((fieldName: string) => {
      const control = this.candidateform.get(fieldName);
      if (control) {
        control.markAsUntouched();
      }
    });
  }

  canExit() {
    if (this.candidateform.dirty) {
      return confirm('You have unsaved changes. Do you really want to discard these changes?');
    }
    else {
      return true;
    }
  }

}
