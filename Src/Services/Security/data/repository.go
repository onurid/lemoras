package data

import (
	"database/sql"
	"fmt"

	_ "github.com/lib/pq"
)

const (
	host     = "db"
	port     = 5432
	user     = "lemoras"
	password = "supersecret"
	dbname   = "lemoras-security-db"
)

type UserApplication struct {
	ApplicationName string
	Id              int
}

type UserResult struct {
	Result       bool
	UserId       int
	AppInsId     int
	RoleId       int
	AppId        int
	Applications []UserApplication
}

func ConnectInfo() {
	psqlInfo := fmt.Sprintf("host=%s port=%d user=%s "+
		"password=%s dbname=%s sslmode=disable",
		host, port, user, password, dbname)

	db, err := sql.Open("postgres", psqlInfo)
	if err != nil {
		panic(err)
	}
	defer db.Close()

	err = db.Ping()
	if err != nil {
		panic(err)
	}

	fmt.Println("Successfully connected!")
}

func CheckUserTest() {
	psqlInfo := fmt.Sprintf("host=%s port=%d user=%s "+
		"password=%s dbname=%s sslmode=disable",
		host, port, user, password, dbname)

	db, err := sql.Open("postgres", psqlInfo)
	if err != nil {
		panic(err)
	}
	defer db.Close()

	sqlStatement := `SELECT user_id, email FROM security.user WHERE username=$1 and password=$2`
	var email string
	var id int
	// // Replace 3 with an ID from your database or another random
	// value to test the no rows use case.
	row := db.QueryRow(sqlStatement, "admin", "admin")

	fmt.Println(row)

	switch err := row.Scan(&id, &email); err {
	case sql.ErrNoRows:
		fmt.Println("No rows were returned!")
	case nil:
		fmt.Println(id, email)
	default:
		panic(err)
	}
}

func CheckUserWithApp(username string, userPassword string, applicationInsId int) (
	result bool, userId int, appInsId int, roleId int, appId int) {
	result = false
	psqlInfo := fmt.Sprintf("host=%s port=%d user=%s "+
		"password=%s dbname=%s sslmode=disable",
		host, port, user, password, dbname)

	db, err := sql.Open("postgres", psqlInfo)
	if err != nil {
		panic(err)
	}
	defer db.Close()

	sqlStatement := `SELECT u.user_id, ur.application_instance_id, ur.role_id, ur.application_id FROM security.user u 
		join security.user_role ur on u.user_id = ur.user_id 
		WHERE u.username=$1 and u.password=$2 and ur.application_instance_id=$3`

	// // Replace 3 with an ID from your database or another random
	// value to test the no rows use case.
	row := db.QueryRow(sqlStatement, username, userPassword, applicationInsId)

	switch err := row.Scan(&userId, &appInsId, &roleId, &appId); err {
	case sql.ErrNoRows:
		fmt.Println("No rows were returned!")
	case nil:
		result = true
		fmt.Println(username, userId, appId, roleId)
	default:
		panic(err)
	}

	return
}

func CheckUser(username string, userPassword string) (
	result UserResult) {
	result.Result = false
	psqlInfo := fmt.Sprintf("host=%s port=%d user=%s "+
		"password=%s dbname=%s sslmode=disable",
		host, port, user, password, dbname)

	db, err := sql.Open("postgres", psqlInfo)
	if err != nil {
		panic(err)
	}
	defer db.Close()

	sqlStatement := `SELECT u.user_id, ur.application_instance_id, ur.role_id, ur.application_id,
			ur.application_tag_name
		FROM security.user u 
		join security.user_role ur on u.user_id = ur.user_id 
		WHERE u.username=$1 and u.password=$2`

	// // Replace 3 with an ID from your database or another random
	// value to test the no rows use case.
	rows, _ := db.Query(sqlStatement, username, userPassword)

	if err != nil {
		panic(err)
	}

	for rows.Next() {
		var tagName string
		switch err := rows.Scan(&result.UserId, &result.AppInsId, &result.RoleId, &result.AppId, &tagName); err {
		case sql.ErrNoRows:
			fmt.Println("No rows were returned!")
		case nil:
			result.Result = true
			fmt.Println(username, result.UserId, result.AppId, result.RoleId)
		default:
			panic(err)
		}
		tmpApp := UserApplication{ApplicationName: tagName, Id: result.AppInsId}

		result.Applications = append(result.Applications, tmpApp)
	}

	return
}
