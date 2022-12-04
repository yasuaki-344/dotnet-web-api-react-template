import { CountStorageService } from "../application";
import { useStorage } from "./Storage";

export const useCountStorage = (): CountStorageService => useStorage();
