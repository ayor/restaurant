import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from "./account/login/login.component";
import { RegisterComponent } from "./account/register/register.component";


const routes: Routes = [
  {
    component: LoginComponent,
    path: 'index'
  },

  {
    component: RegisterComponent,
    path: 'add'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
