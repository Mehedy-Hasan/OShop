import { AuthGuard } from './Auth/auth.guard';
import { HomeComponent } from './home/home.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserComponent } from './user/user.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { SignInComponent } from './user/sign-in/sign-in.component';
import { ForbiddenComponent } from './forbidden/forbidden.component';



const routes: Routes = [
  {
    path: 'user', component: UserComponent,
    children: [
      {path: 'registration', component: RegistrationComponent},
      {path: 'signin', component: SignInComponent},
    ]
  },
  {path: 'home' , component: HomeComponent},
  {path: 'forbidden' , component: ForbiddenComponent, canActivate: [AuthGuard]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
