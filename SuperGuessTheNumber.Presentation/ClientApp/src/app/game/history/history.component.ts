import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { ToastrService } from 'ngx-toastr';
import { HistoryService } from 'src/app/shared/history/history.service'; 
import { UserService } from 'src/app/shared/user/user.service';
@Component({
  selector: 'history',
  templateUrl: './history.component.html',
  styles: [
  ]
})
export class HistoryComponent implements OnInit {
  public currentUser: any;
  public games : any
  selectedRow: any; 
  public i:any;
  constructor(private http: HttpClient, private toastr: ToastrService, private service: HistoryService, private userService: UserService) { }

  ngOnInit(): void {
  this.onGetAllHistoryGames();
  this.games;
  this.currentUser = localStorage.getItem('Email');  }

      onGetAllHistoryGames(){
      this.service.GetAllHistoryGames().subscribe(
      x => {this.games = x;
      console.log(x);
      });
    }
}
