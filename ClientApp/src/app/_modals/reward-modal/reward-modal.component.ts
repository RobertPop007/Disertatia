import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-reward-modal',
  templateUrl: './reward-modal.component.html',
  styleUrls: ['./reward-modal.component.scss']
})
export class RewardModalComponent implements OnInit {
  @Input() rewardType!: string;
  reward!: string;

  constructor() { }

  ngOnInit(): void {
    this.reward = this.rewardType;
  }

}
