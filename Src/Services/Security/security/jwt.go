package security

import (
	"fmt"
	"time"

	"github.com/dgrijalva/jwt-go"
)

var jwtKey = []byte("xxx")

type Credentials struct {
	Password              string `json:"password"`
	Username              string `json:"username"`
	ApplicationInstanceId int    `json:"applicationInstanceId"`
}

type Claims struct {
	Username              string `json:"username"`
	UserId                int    `json:"userId"`
	ApplicationInstanceId int    `json:"applicationInstanceId"`
	RoleId                int    `json:"roleId"`
	ApplicationId         int    `json:"applicationId"`
	jwt.StandardClaims
}

func GenerateToken(
	username string,
	userId int,
	applicationInstanceId int,
	roleId int,
	applicationId int) (tokenString string, err error) {

	// Declare the expiration time of the token
	// here, we have kept it as 5 minutes
	expirationTime := time.Now().Add(3 * 60 * time.Minute)
	// Create the JWT claims, which includes the username and expiry time
	claims := Claims{
		Username:              username,
		UserId:                userId,
		ApplicationInstanceId: applicationInstanceId,
		RoleId:                roleId,
		ApplicationId:         applicationId,
		StandardClaims: jwt.StandardClaims{
			// In JWT, the expiry time is expressed as unix milliseconds
			ExpiresAt: expirationTime.Unix(),
		},
	}

	// Declare the token with the algorithm used for signing, and the claims
	token := jwt.NewWithClaims(jwt.SigningMethodHS512, claims)
	// Create the JWT string
	return token.SignedString(jwtKey)
}

func ValidateToken(tokenString string) bool {
	// sample token string taken from the New example
	//tokenString := "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJmb28iOiJiYXIiLCJuYmYiOjE0NDQ0Nzg0MDB9.u1riaD1rW97opCoAuRCTy4w58Br-Zk-bh7vLiRIsrpU"

	// Parse takes the token string and a function for looking up the key. The latter is especially
	// useful if you use multiple keys for your application.  The standard is to use 'kid' in the
	// head of the token to identify which key to use, but the parsed token (head and claims) is provided
	// to the callback, providing flexibility.
	token, _ := jwt.Parse(tokenString, func(token *jwt.Token) (interface{}, error) {
		// Don't forget to validate the alg is what you expect:
		if _, ok := token.Method.(*jwt.SigningMethodHMAC); !ok {
			return nil, fmt.Errorf("Unexpected signing method: %v", token.Header["alg"])
		}

		// hmacSampleSecret is a []byte containing your secret, e.g. []byte("my_secret_key")
		return jwtKey, nil
	})

	if _, ok := token.Claims.(jwt.MapClaims); ok && token.Valid {
		return true
	}

	return false
}
