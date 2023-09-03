export function isLoggedIn() {
  const user = localStorage.getItem('user')
  return !!user
}

export function isLoggedOut() {
  return !isLoggedIn()
}

export function getCurrUser() {
  const userData = localStorage.getItem('user')
  const currUser = userData ? JSON.parse(userData) : null
  return currUser
}
