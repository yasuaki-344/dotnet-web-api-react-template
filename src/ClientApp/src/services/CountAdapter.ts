import { CountService, useIncrementCount } from "../application";
import { useCountStorage } from "./StorageAdapter";

export const useCounter = (): CountService => {
  const { count, updateCount } = useCountStorage();
  const { increaseCount } = useIncrementCount(count, updateCount);

  return {
    increaseCount,
  };
};
