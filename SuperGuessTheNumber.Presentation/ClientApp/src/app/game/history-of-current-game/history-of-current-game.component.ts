import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { HistoryService } from 'src/app/shared/history/history.service';

@Component({
  selector: 'history-of-current-game',
  templateUrl: './history-of-current-game.component.html',
  styles: [
  ]
})
export class HistoryOfCurrentGameComponent implements OnInit {
  public attempts : any
  constructor( private service: HistoryService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.onGetHistoryOfCurrentGame();
  }

  onGetHistoryOfCurrentGame(){
    this.service.GetHistoryOfCurrentGame().subscribe(
      x => {this.attempts = x;},
      err => {
        if (err.status == 400)
          this.toastr.error(this.attempts = err.error.message, 'Start new game.');
          console.log(err);
      }
    );
  }
}
