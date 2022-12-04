export interface CountStorageService {
  count: number;
  updateCount(count: number): void;
}

export interface CountService {
  increaseCount(): void;
}
