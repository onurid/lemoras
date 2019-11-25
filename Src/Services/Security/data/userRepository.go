package data

import (
	"database/sql"
	"fmt"

	_ "github.com/lib/pq"
)

func GetUser(userId int) {
	psqlInfo := fmt.Sprintf("host=%s port=%d user=%s "+
		"password=%s dbname=%s sslmode=disable",
		host, port, user, password, dbname)

	db, err := sql.Open("postgres", psqlInfo)
	if err != nil {
		panic(err)
	}
	defer db.Close()

	sqlStatement := `SELECT * FROM security.user u WHERE u.userId=$1`

	row := db.QueryRow(sqlStatement, userId)

	switch err := row.Scan(&userId); err {
	case sql.ErrNoRows:
		fmt.Println("No rows were returned!")
	case nil:
		fmt.Println(userId)
	default:
		panic(err)
	}

	return
}

func GetUsers() {
	psqlInfo := fmt.Sprintf("host=%s port=%d user=%s "+
		"password=%s dbname=%s sslmode=disable",
		host, port, user, password, dbname)

	db, err := sql.Open("postgres", psqlInfo)
	if err != nil {
		panic(err)
	}
	defer db.Close()

	sqlStatement := `SELECT * FROM security.user`

	rows, _ := db.Query(sqlStatement)

	if err != nil {
		panic(err)
	}

	for rows.Next() {
		switch err := rows.Scan(); err {
		case sql.ErrNoRows:
			fmt.Println("No rows were returned!")
		case nil:
			fmt.Println()
		default:
			panic(err)
		}
	}

	return
}

func GetUsersRoles() {
	psqlInfo := fmt.Sprintf("host=%s port=%d user=%s "+
		"password=%s dbname=%s sslmode=disable",
		host, port, user, password, dbname)

	db, err := sql.Open("postgres", psqlInfo)
	if err != nil {
		panic(err)
	}
	defer db.Close()

	sqlStatement := `SELECT * FROM security.user u join security.user_role ur on u.user_id = ur.user_id`

	rows, _ := db.Query(sqlStatement)

	if err != nil {
		panic(err)
	}

	for rows.Next() {
		switch err := rows.Scan(); err {
		case sql.ErrNoRows:
			fmt.Println("No rows were returned!")
		case nil:
			fmt.Println()
		default:
			panic(err)
		}
	}

	return
}
