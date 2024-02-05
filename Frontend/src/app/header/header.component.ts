import { Component, ElementRef, HostListener, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { ActivatedRoute, ActivatedRouteSnapshot, Router } from '@angular/router';
import { AuthService } from '../shared/Services/AuthService/auth.service';
import { MatDrawer } from '@angular/material/sidenav';
import { AuthGuard } from '../auth/auth.guard';
import { Location } from '@angular/common';
import { LoginService } from '../shared/Services/LoginService/login.service';
import { MatDialog } from '@angular/material/dialog';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
// Import CookieService
import { CookieService } from 'ngx-cookie-service';
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  Image: any
  warning: any
  selected = navigator.language;
  file:any;
  UserName: string = "USER_NAME"

  User: any;
  IsfirstLogin: boolean = true;
  isAdmin: boolean = false;
  isTPM: boolean = false;
  isRecruiter: boolean = false;
  showheader: boolean = false;
  isEditMode : boolean=false;
  dashboard: boolean = false;
  login: boolean = false;
  mapping: boolean = false;
  sow: boolean = false;
  candidatedetails: boolean = false;
  admin: boolean = false;
  ChangePW: boolean = false;
  roleName: string = "";
  image : string ="";
  mobileNo : string = "";
 // signUpForm!: FormGroup;
  private inactivityTimeout:any;   
  private readonly inactivityDuration =60000;
  
  @ViewChild('drawer', { static: false }) drawer!: MatDrawer;
  @ViewChild('modalContent') modalContent!: TemplateRef<any>;
  constructor(private router: Router, public authservice: AuthService,
    private route: ActivatedRoute, private authGuard: AuthGuard, private location: Location,public loginservice:LoginService,
    public dialog: MatDialog,private fb: FormBuilder,  private snackBar: MatSnackBar) { }
  ngOnInit(): void {

    if (this.authservice.loggedIn()) {
      this.IsfirstLogin = this.authservice.IsFirstLogin() ? true : false;
      this.User = JSON.parse(sessionStorage.getItem("userData") as string);
      this.UserName = this.User.LoginName;
      this.roleName = this.User.RoleName;
      this.image = this.User.Image;
      this.mobileNo=this.User.MobileNo;
      console.log(this.User)
    }

    this.loggedIn();
    this.resetInactivityTimer();

  }
  
  @HostListener('document:mousemove', ['$event'])
  @HostListener('document:keypress')
  handleMouseMove(event: MouseEvent) {
    this.resetInactivityTimer();
  }
 
  resetInactivityTimer() {
    clearTimeout(this.inactivityTimeout);
 
    this.inactivityTimeout = setTimeout(() => {
      this.logout();
    }, this.inactivityDuration);
  }
 
  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 2000,
      panelClass:['red-snackbar']
    });
  }

  logout() {
    sessionStorage.clear();
    this.loggedIn();
    
    this.router.navigate(["/login"]).then(() => {
      window.location.reload();
    });
  

  }
  
  loggedIn() {

    this.User = JSON.parse(sessionStorage.getItem("userData") as string);
    if (
      sessionStorage.getItem("userData") != null ||
      sessionStorage.getItem("userData") != undefined
    ) {
      this.login = true;
      this.dashboard = true;
      let data = sessionStorage.getItem("userData");
      let resData = data ? JSON.parse(data) : null;
      let ScreenNames = resData.ScreenNames.split(",");



      for (let i = 0; i < ScreenNames.length; i++) {
        if (ScreenNames[i].toLowerCase() == "sow") {

          this.sow = true;
        }
        else if (ScreenNames[i].toLowerCase() == "candidatedetails") {
          this.candidatedetails = true;
        }
        else if (ScreenNames[i].toLowerCase() == "mapping") {
          this.mapping = true;
        }

        else if (ScreenNames[i].toLowerCase() == "changepassword") {
          this.ChangePW = true;
        }

        else if (ScreenNames[i].toLowerCase() == "admin") {
          this.isAdmin = true;
        }
        else if (ScreenNames[i].toLowerCase() == "usttpm") {
          this.isTPM = true;
        }
        

      }
    }

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
  UpdateLoginData(item: any) {
    this.User = JSON.parse(sessionStorage.getItem("userData") as string);
  
    // Check if a new image is selected
    if (this.Image) {
      item.Image = this.Image; // If new image selected, use the new image
    } else {
      // If no new image selected, retain the previous image
      item.Image = this.User.Image;
    }
  
    this.User.LoginName = item.LoginName;
    this.User.Image = item.Image;
    this.User.MobileNo = item.MobileNo;
  
    sessionStorage.setItem("userData", JSON.stringify(this.User));
  
    this.loginservice.updatedata(item.EmailId, item).subscribe(
      (data) => {
        console.log(item.LoginName);
        this.openSnackBar(data, 'ok');
        window.location.reload();
      },
      (err) => {
        console.log(err);
      }
    );
  
    this.UserName = item.LoginName;
  }
  openDialog() {
   
    const dialogRef = this.dialog.open(this.modalContent);

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }
}
