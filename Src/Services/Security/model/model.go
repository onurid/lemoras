package model

import (
	"time"
)

type ConfigContract struct {
	Template string
	Config   string
}

type LoginApplicationContract struct {
	Token      string
	ConfigData ConfigContract
}

type Result struct {
	Success bool
	Data    LoginApplicationContract
}

type User struct {
	Id            int       `json:"id"`
	Username      string    `json:"username"`
	Password      string    `json:"password"`
	Email         string    `json:"email"`
	Firstname     string    `json:"firstname"`
	Lastname      string    `json:"lastname"`
	Active        bool      `json:"active"`
	LastLoginDate time.Time `json:"lastlogindate"`
}

type UserRole struct {
	Id                    int `json:"id"`
	UserId                int `json:"userid"`
	ApplicationInstanceId int `json:"applicationinstanceid"`
	RoleId                int `json:"roleid"`
}

type UserSession struct {
	ApplicationInstanceId int       `json:"applicationinstanceid"`
	ApplicationId         int       `json:"applicationid"`
	Userid                int       `json:"userid"`
	ExpireDate            time.Time `json:"expiredate"`
	Username              string    `json:"username"`
	DatabaseName          string    `json:"databasename"`
	ConnectionString      string    `json:"connectionstring"`
	RoleId                int       `json:"roleid"`
	ModuleIds             []int     `json:"moduleids"`
}
