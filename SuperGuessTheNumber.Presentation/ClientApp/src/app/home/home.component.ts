import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: []
})
export class HomeComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {
  }


  public onLogout() {
    localStorage.removeItem('token');
    this.router.navigate(['/user/login']);
  }

  onPlay(){
    this.router.navigate(['/game']);
  }

}