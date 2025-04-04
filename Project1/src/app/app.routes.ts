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
import { HomeComponent } from './componenets/home/home.component';
import { BookingComponent } from './componenets/Methods/booking/booking.component';
import { AuthGuard } from './componenets/guard/auth.guard';


export const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent},
  { path: 'register', component: RegisterComponent },
  {path :'userdashboard',component:UserDashboardComponent, canActivate:[AuthGuard]},
  {path:'admindashboard', component:AdminDashboardComponent,canActivate:[AuthGuard]},
  {path:'add-event',component:AddEventComponent},
  { path: 'update-event/:id', component: UpdateEventComponent },
  {path:'booking-payment',component:BookingPaymentComponent},
  // {path:'booking-event',component:BookingComponent},
  { path: 'book/:id', component: BookingComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  

];



// export default routes;
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
