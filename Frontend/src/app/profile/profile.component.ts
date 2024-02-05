import { Component } from '@angular/core';
import { LoginService } from '../shared/Services/LoginService/login.service';
import { AuthService } from '../shared/Services/AuthService/auth.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent {
  warning: any
  selected = navigator.language;
  file:any;
  UserName: string = "USER_NAME"
  Image: any
  User: any;
  roleName: string = "";
  image : string ="";
  mobileNo : string = "";
  IsfirstLogin: boolean = true;
constructor(public loginservice:LoginService, public authservice: AuthService){}
ngOnInIt():void{
  if (this.authservice.loggedIn()) {
    this.IsfirstLogin = this.authservice.IsFirstLogin() ? true : false;
    this.User = JSON.parse(sessionStorage.getItem("userData") as string);
    this.UserName = this.User.LoginName;
    this.roleName = this.User.RoleName;
    this.image = this.User.Image;
    this.mobileNo=this.User.MobileNo;
    console.log(this.User)
  }
}

onImageSelected(event: any) {
  this.file = event.target.files[0];


  const reader = new FileReader();
  reader.readAsDataURL(this.file);
  reader.onload = () => {
    const base64Image = reader.result!.toString();
    this.Image = base64Image
  console.log(this.Image)

    // save the base64Image in a variable or pass it to a service for further processing
  };
}
UpdateLoginData(item: any) {
    
  var previousData=JSON.parse(sessionStorage.getItem("userData") as string);
  console.log(previousData.Image)
  previousData.LoginName=item.LoginName
  item.Image= this.Image
   previousData.Image=item.Image
   previousData.MobileNo=item.MobileNo;
  sessionStorage.setItem("userData",previousData);
  console.log(item.LoginName);
  
  this.loginservice.updatedata(item.EmailId, item).subscribe(
    (data) => {
       console.log(item.LoginName)
     
      alert(data)
    },
    (err) => {
      console.log(err);
    }
  )
  this.UserName=item.LoginName;
}

}

