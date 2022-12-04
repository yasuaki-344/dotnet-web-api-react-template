import React, {
  createContext,
  ReactNode,
  useContext,
  useMemo,
  useState,
} from "react";

const StorageContext = createContext<any>({});
export const useStorage = () => useContext(StorageContext);

export const Provider = ({ children }: { children: ReactNode }) => {
  const [count, setCount] = useState(0);

  const value = useMemo(() => ({ count, updateCount: setCount }), [count]);

  return (
    <StorageContext.Provider value={value}>{children}</StorageContext.Provider>
  );
};
