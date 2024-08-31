import './style.css'

const apiUrl = 'http://localhost:8000/todo';

// Expose functions to global scope
window.addTask = addTask;
window.updateTask = updateTask;

document.addEventListener('DOMContentLoaded', () => {
  fetchTasks();
});

async function fetchTasks() {
  try {
    const response = await fetch(apiUrl);
    if (!response.ok) throw new Error('Network response was not ok');
    const tasks = await response.json();
    displayTasks(tasks);
  } catch (error) {
    console.error('Error fetching tasks:', error);
  }
}

function displayTasks(tasks) {
  const taskList = document.getElementById('taskList');
  taskList.innerHTML = '';
  tasks.forEach(task => {
    const taskItem = document.createElement('li');
    taskItem.innerHTML = `
      <input type="checkbox" ${task.isCompleted ? 'checked' : ''} onchange="updateTask(${task.id}, this.checked)" />
      ${task.description}
    `;
    taskList.appendChild(taskItem);
  });
}

async function addTask() {
  const newTaskInput = document.getElementById('newTaskInput');
  const description = newTaskInput.value.trim();
  if (description === '') return;
  try {
    const response = await fetch(apiUrl, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({ description, isCompleted: false })
    });
    if (!response.ok) throw new Error('Network response was not ok');
    newTaskInput.value = '';
    fetchTasks();
  } catch (error) {
    console.error('Error adding task:', error);
  }
}

async function updateTask(id, isCompleted) {
  try {
    const response = await fetch(`${apiUrl}/${id}`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({ isCompleted })
    });
    if (!response.ok) throw new Error('Network response was not ok');
    fetchTasks();
  } catch (error) {
    console.error('Error updating task:', error);
  }
}

