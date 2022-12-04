import { afterEach, describe, expect, it, vi } from "vitest";
import { CountUseCase } from "../CountUseCase";

describe("CountUseCaseTest", () => {
  afterEach(() => {
    vi.restoreAllMocks();
  });

  it("increaseCount correctly", () => {
    const count = 0;
    const updateCount = vi.fn();
    const { increaseCount } = CountUseCase(count, updateCount);

    increaseCount();

    expect(updateCount).toHaveBeenCalledTimes(1);
  });
});
