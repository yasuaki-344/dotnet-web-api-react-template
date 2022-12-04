import { CountService } from "../application";

export const useCounter = (): CountService => ({
    increaseCount: () => console.log("this is test"),
  });
