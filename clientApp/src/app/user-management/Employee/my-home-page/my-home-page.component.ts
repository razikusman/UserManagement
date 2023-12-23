import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-my-home-page',
  templateUrl: './my-home-page.component.html',
  styleUrls: ['./my-home-page.component.css']
})
export class MyHomePageComponent {
  /**
   *
   */
  constructor(private route:Router) {
  }
  goToMyDetailspage(){
    this.route.navigate(["/MyProfile"])
  }
}
