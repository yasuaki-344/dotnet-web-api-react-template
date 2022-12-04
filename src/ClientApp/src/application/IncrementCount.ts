export const useIncrementCount = (
  count: number,
  updateCount: (count: number) => void
) => {
  const increaseCount = () => updateCount(count + 1);

  return {
    increaseCount,
  };
};
