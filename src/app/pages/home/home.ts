import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-home',
  imports: [RouterLink, CommonModule],
  templateUrl: './home.html',
  styleUrl: './home.scss'
})
export class Home implements OnInit {
  displayedText: string = '';
  fullName: string = 'Ezana Tefera';
  showCursor: boolean = true;

  constructor(private cdr: ChangeDetectorRef) {}

  ngOnInit(): void {
    this.typeWriter();
    setInterval(() => {
      this.showCursor = !this.showCursor;
      this.cdr.detectChanges();
    }, 500);
  }

  typeWriter(): void {
    let i = 0;
    setTimeout(() => {
      const interval = setInterval(() => {
        if (i < this.fullName.length) {
          this.displayedText += this.fullName.charAt(i);
          i++;
          this.cdr.detectChanges();
        } else {
          clearInterval(interval);
        }
      }, 150);
    }, 500);
  }
}