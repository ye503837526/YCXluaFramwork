local json =require "rapidjson"
local APP = CS.UnityEngine.Application
local FilesUtil = CS.Legend.Framework.FilesUtil
local MIDPATH = "/Legend/GameHall/Asset/GameRes/Config/Json/"
local EXPORTPATH = "/Legend/GameHall/Lua/Config/"

local JsonToLuaTable = {}

function JsonToLuaTable:Convert(jsonfile,keyname)
	local fullpath = APP.dataPath.. MIDPATH ..jsonfile..".json"
	print("Convert:",fullpath)
	local data = FilesUtil.ReadAllText(fullpath)
	local tb = json.decode(data)
	local str = "local " .. jsonfile .. " = {\n"
	for i,v in ipairs(tb) do 
		local id = v[keyname]
		local temp = {}
		for k,v in pairs(v) do
			local strtemp =  ""
			local tp = type(v)
			if tp == "number" then
				strtemp =  k .. "=" .. v
			elseif tp =="string" then
				strtemp =  k .. "=" .. "\"" .. v .. "\""
 			else
				Debug.LogError("Convet Error!Invalid ValueType:"..jsonfile..",key:"..v.."type:"..tp)
			end
			table.insert(temp,strtemp)
		end
		local midstr = table.concat(temp,",")
		str = str .. (string.format("	[%s]={%s},\n",id,midstr))
	end
	str = str .. "\n} \nreturn " .. jsonfile
	local outpath = APP.dataPath.. EXPORTPATH ..jsonfile..".lua"
	print("outpath:",outpath)
	FilesUtil.WriteAllText(outpath,str)
end

function JsonToLuaTable:ConvertAll()
	self:Convert("Item","iID")
end

JsonToLuaTable:ConvertAll()

return JsonToLuaTable