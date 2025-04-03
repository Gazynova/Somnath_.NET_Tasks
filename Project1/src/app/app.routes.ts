import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
// import { LoginComponent } from './auth/login/login.component';
import { LoginComponent } from './componenets/auth/login/login.component';
// import { RegisterComponent } from './auth/register/register.component';
import { RegisterComponent } from './componenets/auth/register/register.component';
// import {UserDashboardComponent} from './componenets/dashboards/user-dashboard.component';
import { UserDashboardComponent } from './componenets/dashboards/user-dashboard/user-dashboard.component';
import { AdminDashboardComponent } from './componenets/dashboards/admin-dashboard/admin-dashboard.component';
import { AddEventComponent } from './componenets/Methods/add-event/add-event.component';
import {UpdateEventComponent} from './componenets/Methods/update-event/update-event.component';
import{BookingPaymentComponent} from './componenets/Methods/booking-payment/booking-payment.component';


const routes: Routes = [
  { path: 'login', component: LoginComponent},
  { path: 'register', component: RegisterComponent },
  {path :'userdashboard',component:UserDashboardComponent},
  {path:'admindashboard', component:AdminDashboardComponent},
  {path:'add-event',component:AddEventComponent},
  { path: 'update-event/:id', component: UpdateEventComponent },
  {path:'booking-payment',component:BookingPaymentComponent},

  { path: '', redirectTo: '/login', pathMatch: 'full' },
  

];
export default routes;
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
