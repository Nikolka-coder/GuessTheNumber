import { AuthGuard } from './auth/auth.guard';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserComponent } from './user/user.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { LoginComponent } from './user/login/login.component';
import { HomeComponent } from './home/home.component';
import { GameComponent } from './game/game.component';
import { HistoryComponent } from './game/history/history.component';
import { HistoryOfCurrentGameComponent } from './game/history-of-current-game/history-of-current-game.component';

const routes: Routes = [
  {path:'',redirectTo:'/user/login',pathMatch:'full'},
  {
    path: 'user', component: UserComponent,
    children: [
      { path: 'registration', component: RegistrationComponent },
      { path: 'login', component: LoginComponent }
    ]
  },
  {path:'home',component:HomeComponent}, //,canActivate:[AuthGuard]
  {path:'game',component:GameComponent},
  {path: 'history', component: HistoryComponent},
  {path: 'historyofcurrentgame', component: HistoryOfCurrentGameComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }