import { Component, computed, inject, input, signal } from '@angular/core';
import { DecimalPipe, NgOptimizedImage } from '@angular/common';
import { toObservable, toSignal } from '@angular/core/rxjs-interop';
import { switchMap } from 'rxjs';
import { WorthinatorService } from '../../services/worthinator-service';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-game-details-component',
  imports: [DecimalPipe, NgOptimizedImage, RouterLink],
  templateUrl: './game-details-component.html',
  styleUrl: './game-details-component.css',
})
export class GameDetailsComponent {
  private readonly worthinatorService = inject(WorthinatorService);

  id = input.required<string>();
  gameInfo = toSignal(
    toObservable(this.id).pipe(switchMap((id) => this.worthinatorService.getGameInfo(Number(id)))),
  );

  readonly steamBaseUrl = 'https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/';
  private useFallback = signal<boolean>(false);

  bannerUrl = computed(() => {
    const currentId = this.id();
    if (this.useFallback()) {
      return `${this.steamBaseUrl}${currentId}/header.jpg`;
    }
    return `${this.steamBaseUrl}${currentId}/library_hero.jpg`;
  });

  handleImageError() {
    if (!this.useFallback()) {
      this.useFallback.set(true);
    }
  }
}
