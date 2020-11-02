import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup} from "@angular/forms";
import {UserService} from "../../shared/services/user.service";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private User: UserService) { }

  ngOnInit(): void {
  }

  UserInfo = new FormGroup({
    Email: new FormControl(),
    Password: new FormControl()
  })

  VerifyUser() {
    this.User.Authenticate(this.UserInfo.value).subscribe(result => {
      console.warn(result)
      // this.collection = result
    }, error => console.warn(error))
  }

}
