import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FooterComponent } from './components/footer/footer.component';
import { HeaderComponent } from './components/header/header.component';
import { AlertComponent } from './components/alert/alert.component';



@NgModule({
  declarations: [FooterComponent, HeaderComponent, AlertComponent],
  imports: [
    CommonModule
  ]
})
export class CoreModule { }
