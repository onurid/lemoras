package model

import (
	"time"
)

type UserApplication struct {
	ApplicationName string `json:"applicationName"`
	Id              int    `json:"id"`
}

type LoginApplicationContract struct {
	Token        string            `json:"token"`
	Applications []UserApplication `json:"applications"`
}

type Result struct {
	Success bool                     `json:"success"`
	Data    LoginApplicationContract `json:"data"`
	Message string                   `json:"message"`
}
type UserSession struct {
	ApplicationInstanceId int       `json:"applicationinstanceid"`
	Userid                int       `json:"userid"`
	ExpireDate            time.Time `json:"expiredate"`
	Username              string    `json:"username"`
	RoleId                int       `json:"roleid"`
	ApplicationId         int       `json:"applicationid"`
}
