import { Component, OnInit } from '@angular/core';
// import {AccountService} from "../../../core/services";
// import {Router} from "@angular/router";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html'
})

export class HeaderComponent implements OnInit {

  constructor(/*private account: AccountService, private router: Router*/) {
    // if (!this.account.userValue) {
    //   // this.router.navigate(['/']);
    // }
  }

  ngOnInit(): void {

  }

}
