import { CountService, CountUseCase } from "../application";
import { useCountStorage } from "./StorageAdapter";

export const useCounter = (): CountService => {
  const { count, updateCount } = useCountStorage();
  const { increaseCount } = CountUseCase(count, updateCount);

  return {
    increaseCount,
  };
};
