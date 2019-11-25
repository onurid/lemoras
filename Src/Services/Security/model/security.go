package model

import (
	"time"
)

type User struct {
	Id            int
	Username      string
	Password      string
	Email         string
	Firstname     string
	Lastname      string
	Active        bool
	LastLoginDate time.Time
}

type UserRole struct {
	Id                    int
	UserId                int
	ApplicationInstanceId int
	RoleId                int
	ApplicationId         int
	ApplicationTagName    string
}
