package model

type Command struct {
	CommandName       string `json:"commandName"`
	BusinessServiceId string `json:"businessServiceId"`
	Id                int    `json:"id"`
}

type RoleAuthorise struct {
	Id        int `json:"id"`
	CommandId int `json:"commandId"`
	RoleId    int `json:"roleId"`
}

type ApplicationModule struct {
	Id              int `json:"id"`
	ApplicationId   int `json:"applicationId"`
	BusinessLogicId int `json:"businessLogicId"`
	ModuleId        int `json:"moduleId"`
}

type BusinessLogic struct {
	Id                int    `json:"id"`
	BusinessLogicName string `json:"businessLogicName"`
	UniqueKey         string `json:"uniqueKey"`
	BusinessServiceId int    `json:"businessServiceId"`
}

type BusinessService struct {
	Id                  int    `json:"id"`
	BusinessServiceName string `json:"BusinessServiceName"`
	BusinessServiceKey  string `json:"BusinessServiceKey"`
}
