package main

import (
	"log"
	"net/http"

	"./data"
	"./model"
)

func main() {
	var user model.User
	user.Id = 1
	http.HandleFunc("/api/auth/token", Signin)
	http.HandleFunc("/api/auth/myprofile", GetProfile)
	http.HandleFunc("/api/auth/user", GetUsers)
	http.HandleFunc("/api/auth/user-role", GetUsers)
	http.HandleFunc("/check-db", Check)
	http.HandleFunc("/check-user", CheckUser)
	log.Fatal(http.ListenAndServe(":80", nil))
}

func Check(w http.ResponseWriter, r *http.Request) {
	data.ConnectInfo()
}

func CheckUser(w http.ResponseWriter, r *http.Request) {
	data.CheckUserTest()
}

func setupResponse(w *http.ResponseWriter, req *http.Request) {
	(*w).Header().Set("Access-Control-Allow-Origin", "*") // allow debug.lemoras.site & lemoras.site for security
	(*w).Header().Set("Access-Control-Allow-Methods", "POST, GET, OPTIONS, PUT, DELETE")
	(*w).Header().Set("Access-Control-Allow-Headers", "Accept, Content-Type, Content-Length, Accept-Encoding, X-CSRF-Token, Authorization")
}
