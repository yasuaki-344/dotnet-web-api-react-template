type Dependency = {
  count: number;
  updateCount: (count: number) => void;
};

export const useIncrementCount = (dependency: Dependency) => {
  const { count, updateCount } = dependency;

  const increaseCount = () => updateCount(count + 1);

  return {
    increaseCount,
  };
};
