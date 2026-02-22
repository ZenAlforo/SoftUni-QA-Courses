const { test, expect } = require("@playwright/test");
const { styleText } = require("node:util");

test.describe("Testing add task functionality", () => {
  test("user can add a task", async ({ page }) => {
    // arrange
    await page.goto("http://localhost:8085");

    // act
    const inputField = await page.locator("#task-input");
    await inputField.fill("Test Task");
    await page.locator("#add-task").click();
    const newTask = await page.locator("#task-list li").last().textContent();

    // assert
    //await expect(newTask).toBeVisible();
    await expect(newTask).toContain("Test Task");
  });
});

test.describe("Testing delete task functionality", () => {
  test("user can delete a tasky", async ({ page }) => {
    await page.goto("http://localhost:8085");

    // Add task
    await page.fill("#task-input", "Task to be deleted");
    await page.click("#add-task");

    // Delete task
    const task = page.locator("#task-list li", {
      hasText: "Task to be deleted",
    });
    await task.locator('button:has-text("Delete")').click();

    // Verify it's gone
    const taskList = await page.locator("#task-list li").allTextContents();
    expect(taskList).not.toContain("Task to be deleted");
  });
});

test.describe("Testing that a user can mark a task as completed", () => {
  test("user can mark a task as completed", async ({ page }) => {
    // arrange
    await page.goto("http://localhost:8085");
    await page.fill("#task-input", "New Task");
    await page.click("#add-task");

    // act
    await page.click(".task-complete");

    // assert
    const completedTask = page.locator(".task.completed", {
      hasText: "New Task",
    });
    await expect(completedTask).toBeVisible();
  });
});

test.describe("Testing that a user can filter tasks", () => {
  test("user can filter completed tasks", async ({ page }) => {
    // arrange
    await page.goto("http://localhost:8085");
    await page.fill("#task-input", "Task 1");
    await page.click("#add-task");
    await page.fill("#task-input", "Task 2");
    await page.click("#add-task");
    await page.click(".task-complete");

    // act
    await page.click(".task .task-complete");
    await page.selectOption("#filter", "completed");

    // assert

    const task1 = page.locator(".task.completed", { hasText: "Task 1" });
    await expect(task1).toBeVisible();

    const task2 = page.locator(".task.completed", { hasText: "Task 2" });
    await expect(task2).toHaveCount(0);
  });

  test("user can filter active tasks", async ({ page }) => {
    // arrange
    await page.goto("http://localhost:8085");

    await page.fill("#task-input", "Task 1");
    await page.click("#add-task");

    await page.fill("#task-input", "Task 2");
    await page.click("#add-task");

    await page.click(".task-complete");

    // act
    await page.click(".task .task-complete");
    await page.selectOption("#filter", "active");

    // assert

    const task2 = page.locator(".task", { hasText: "Task 2" });
    await expect(task2).toBeVisible();

    const task1 = page.locator(".task.completed", { hasText: "Task 1" });
    await expect(task1).toBeHidden();
  });

  test("user can filter all tasks", async ({ page }) => {
    // arrange
    await page.goto("http://localhost:8085");

    await page.fill("#task-input", "Task 1");
    await page.click("#add-task");

    await page.fill("#task-input", "Task 2");
    await page.click("#add-task");

    await page.click(".task-complete");

    // act
    await page.click(".task .task-complete");
    await page.selectOption("#filter", "all");

    // assert

    const activeTask = page.locator(".task", { hasText: "Task 2" });
    await expect(activeTask).toBeVisible();

    const completedTask = page.locator(".task.completed", {
      hasText: "Task 1",
    });
    await expect(completedTask).toBeVisible();
  });
});
