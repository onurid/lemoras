package main

import (
	"encoding/json"
	"log"
	"net/http"

	"./data"
	"./model"
	"./security"
)

var users = map[string]string{
	"admin": "admin",
	"user1": "password1",
	"user2": "password2",
}

func main() {
	var user model.User
	user.Id = 1
	http.HandleFunc("/token", Signin)
	http.HandleFunc("/check-db", Check)
	http.HandleFunc("/check-user", CheckUser)
	log.Fatal(http.ListenAndServe(":8088", nil))
}

func Signin(w http.ResponseWriter, r *http.Request) {
	var creds security.Credentials
	// Get the JSON body and decode into credentials
	err := json.NewDecoder(r.Body).Decode(&creds)
	if err != nil {
		// If the structure of the body is wrong, return an HTTP error
		w.WriteHeader(http.StatusBadRequest)
		return
	}
	// Get the expected password from our in memory map
	// expectedPassword, ok := users[creds.Username]
	resultCheckUser := data.CheckUser(creds.Username, creds.Password)

	// If a password exists for the given user
	// AND, if it is the same as the password we received, the we can move ahead
	// if NOT, then we return an "Unauthorized" status
	// if !ok || expectedPassword != creds.Password {
	// 	w.WriteHeader(http.StatusUnauthorized)
	// 	return
	// }
	if !resultCheckUser {
		w.WriteHeader(http.StatusUnauthorized)
		return
	}

	tokenString, err := security.GenerateToken(creds.Username)
	if err != nil {
		// If there is an error in creating the JWT return an internal server error
		w.WriteHeader(http.StatusInternalServerError)
		return
	}

	data := model.LoginApplicationContract{Token: tokenString}

	result := model.Result{Success: true, Data: data}

	jsonResult, jsonerr := json.Marshal(result)

	if jsonerr != nil {
		// If there is an error in creating the JWT return an internal server error
		w.WriteHeader(http.StatusInternalServerError)
		return
	}
	w.Write(jsonResult)
	// Finally, we set the client cookie for "token" as the JWT we just generated
	// we also set an expiry time which is the same as the token itself
	// http.SetCookie(w, &http.Cookie{
	// 	Name:    "token",
	// 	Value:   tokenString,
	// 	Expires: expirationTime,
	// })
}

func Check(w http.ResponseWriter, r *http.Request) {
	data.ConnectInfo()
}

func CheckUser(w http.ResponseWriter, r *http.Request) {
	data.CheckUserTest()
}
