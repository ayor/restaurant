import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup} from "@angular/forms";
import {UserService} from "../../shared/services/user.service";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private user: UserService) { }

  ngOnInit(): void {
  }

  NewUser = new FormGroup({
    FirstName: new FormControl(),
    LastName: new FormControl(),
    Sex: new FormControl(),
    Email: new FormControl(),
    Telephone: new FormControl()
  })

  AddUser() {
    this.user.Add(this.NewUser.value).subscribe(result => {
      console.warn(result)
      // this.collection = result
    }, error => console.warn(error))
  }

}
