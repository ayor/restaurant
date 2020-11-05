import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedDirective } from './directives/shared.directive';
import { SharedPipe } from './pipes/shared.pipe';
import { ButtonComponent } from './components/button/button.component';
import { CapitalizePipe } from './pipes/capitalize.pipe';
import { SafePipe } from './pipes/safe.pipe';
import { AuthDirective } from './directives/auth.directive';



@NgModule({
  declarations: [SharedDirective, SharedPipe, ButtonComponent, CapitalizePipe, SafePipe, AuthDirective],
  imports: [
    CommonModule
  ]
})
export class SharedModule { }
