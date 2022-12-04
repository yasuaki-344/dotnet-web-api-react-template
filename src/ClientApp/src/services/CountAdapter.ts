import { CountService } from "../application";
import { useCountStorage } from "./StorageAdapter";

export const useCounter = (): CountService => {
  const { count, updateCount } = useCountStorage();

  return {
    increaseCount: () => updateCount(count + 1),
  };
};
