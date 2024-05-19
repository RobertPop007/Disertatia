import { Component, Input, Output, EventEmitter } from '@angular/core';
@Component({
  selector: 'app-star-rating',
  templateUrl: './star-rating.component.html',
  styleUrls: ['./star-rating.component.scss']
})
export class StarRatingComponent {

  @Input() maxStars: number = 10;
  @Output() ratingChanged: EventEmitter<number> = new EventEmitter<number>();

  currentRating: number = 0;
  stars: number[] = [];

  constructor() { 
    this.stars = Array(this.maxStars).fill(0).map((x, i) => i + 1);
  }

  onStarHover(index: number): void {
      this.currentRating = index; // Only update if no star is selected
      this.ratingChanged.emit(index);
  }

  onStarClick(index: number): void {
    this.currentRating = index;
    this.ratingChanged.emit(index);
  }

  onMouseLeave(): void {
    if (this.currentRating === 0) {
      this.currentRating = 0; // Reset only if no star is selected
    }
  }

  resetStars(): void {
    this.currentRating = 0;
  }
}
