package main

import (
	"encoding/json"
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

func Signin(w http.ResponseWriter, r *http.Request) {

	setupResponse(&w, r)
	if (*r).Method == "OPTIONS" {
		return
	}

	var creds security.Credentials
	// Get the JSON body and decode into credentials
	err := json.NewDecoder(r.Body).Decode(&creds)
	if err != nil {
		// If the structure of the body is wrong, return an HTTP error
		w.WriteHeader(http.StatusBadRequest)
		return
	}

	var tokenString string
	var applications []model.UserApplication
	// Get the expected password from our in memory map
	// expectedPassword, ok := users[creds.Username]
	if creds.ApplicationInstanceId > 0 {
		var userId int
		var appInsId int
		var roleId int
		var appId int
		resultCheckUser, userId, appInsId, roleId, appId := data.CheckUserWithApp(creds.Username, creds.Password, creds.ApplicationInstanceId)

		if !resultCheckUser {
			//w.WriteHeader(http.StatusUnauthorized)
			result := model.Result{Success: false, Message: "Username or password wrong!"}
			jsonResult, jsonerr := json.Marshal(result)

			if jsonerr != nil {
				// If there is an error in creating the JWT return an internal server error
				w.WriteHeader(http.StatusInternalServerError)
				return
			}
			w.Write(jsonResult)
			return
		}
		tokenString, err = security.GenerateToken(creds.Username, userId, appInsId, roleId, appId)
		if err != nil {
			// If there is an error in creating the JWT return an internal server error
			w.WriteHeader(http.StatusInternalServerError)
			return
		}
	} else {
		userResult := data.CheckUser(creds.Username, creds.Password)
		if len(userResult.Applications) == 1 {
			tokenString, err = security.GenerateToken(creds.Username, userResult.UserId,
				userResult.AppInsId, userResult.RoleId, userResult.AppId)
			if err != nil {
				// If there is an error in creating the JWT return an internal server error
				w.WriteHeader(http.StatusInternalServerError)
				return
			}
		} else if len(userResult.Applications) == 0 {
			result := model.Result{Success: false, Message: "Username or password wrong!"}

			jsonResult, jsonerr := json.Marshal(result)

			if jsonerr != nil {
				// If there is an error in creating the JWT return an internal server error
				w.WriteHeader(http.StatusInternalServerError)
				return
			}
			w.Write(jsonResult)
			return
		} else {
			for i := 0; i < len(userResult.Applications); i++ {
				tmpApp := model.UserApplication{
					ApplicationName: userResult.Applications[i].ApplicationName,
					Id:              userResult.Applications[i].Id}
				applications = append(applications, tmpApp)
			}
		}
	}
	// If a password exists for the given user
	// AND, if it is the same as the password we received, the we can move ahead
	// if NOT, then we return an "Unauthorized" status
	// if !ok || expectedPassword != creds.Password {
	// 	w.WriteHeader(http.StatusUnauthorized)
	// 	return
	// }

	data := model.LoginApplicationContract{Token: tokenString, Applications: applications}

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
