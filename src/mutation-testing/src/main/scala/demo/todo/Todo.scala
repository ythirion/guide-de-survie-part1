package demo.todo

final case class Todo(title: String, description: String)

class ToDoService(
    private val repository: TodoRepository
) {
  def search(text: String): List[Todo] = {
    repository.search(text)
  }
}

trait TodoRepository {
  def search(text: String): List[Todo]
}
