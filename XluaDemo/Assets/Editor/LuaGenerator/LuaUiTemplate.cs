
using UnityEngine;

public class LuaUiTemplate
{
    static public string lua_ui_parser_template = @"
--DO NOT  modify it!
--auto generated at #A!
local  #1 = {   }

function #1:Parse( view )
    local aide = ViewAide
    local ui = {}
#9
#2
    return ui
end

return #1

";

    static public string lua_ui_behavior_template = @"local _ENV = require ""#K.Lua.MediatorModule.View.BaseAide.ViewEnv""
#D
local #1 = class(""#1"",ViewBase)

function #1:ParseUI()
    if self.ui ~= nil then return end
#B
#9#2#C
end

function #1:Awake()
    self:Register(""#1"")
    self:ParseUI()
end

function #1:Start()

end
#4
function #1:OnDestroy()
    self:UnRegister()
end

return #1

";

    public const string template_parsecode_h = @"local ui = require ""{0}.Lua.MediatorModule.View.{1}.{2}UI""";
    //const string template_parsecode_l = @"local aide = require ""GameHall.Lua.View.Manager.ViewAide""";
    public const string template_parsecode_0 = "    self.ui = ui:Parse(self)";
    public const string template_parsecode_1 = @"    local aide = ViewAide
    local ui = {}";
    public const string template_parsecode_2 = "    self.ui = ui";

    #region UI_TEMPLATE
    public const string template_injection_lua = "    ui.{0} = aide:GetLuaBehaviour(view.{1})\n";
    public const string template_injection_template = "    ui.{0} = aide:GetComponent(view.{1},{2})\n";
    public const string template_button_string = "    aide:AddButtonEvent(ui.{0},view,view.On{1}Event)\n";
    public const string template_button_action = @"
function {0}:On{1}Event(button)
       
end
";

    //toggle event
    public const string template_toggle_string = "    aide:AddToggleEvent(ui.{0},view,view.On{1}Event)\n";
    public const string template_toggle_action = @"
function {0}:On{1}Event(toggle,v)
       
end
";

    //inputfield event
    public const string template_input_string = "    aide:AddInputEvent(ui.{0},view,view.On{1}Event)\n";
    public const string template_input_action = @"
function {0}:On{1}Event(input,text)
       
end
";

    public const string template_tmp_inputfield_string = "    aide:AddTmpInputEvent(ui.{0},view,view.On{1}Event)\n";
    public const string template_tmp_inputfield_action = @"
function {0}:On{1}Event(input,text,eventname)
       
end
";

    //slider
    public const string template_slider_string = "    aide:AddSliderEvent(ui.{0},view,view.On{1}Event)\n";
    public const string template_slider_action = @"
function {0}:On{1}Event(slider,v)
       
end
";

    public const string template_injection_lua_arr = "    ui.{0}s = aide:GetLuaBehaviours(view.{1})\n";
    public const string template_injection_template_arr = "    ui.{0}s = aide:GetComponents(view.{1},{2})\n";
    public const string template_button_string_arr = "    aide:AddButtonEvents(ui.{0}s,view,view.On{1}Events)\n";
    public const string template_button_action_arr = @"
function {0}:On{1}Events(button,index)
       
end
";
    public const string template_toggle_string_arr = "    aide:AddToggleEvents(ui.{0}s,view,view.On{1}Events)\n";
    public const string template_toggle_action_arr = @"
function {0}:On{1}Events(toggle,v,index)
       
end
";

    public const string template_input_string_arr = "    aide:AddInputEvents(ui.{0}s,view,view.On{1}Events)\n";
    public const string template_input_action_arr = @"
function {0}:On{1}Events(input,text,index)
       
end
";
    public const string template_tmp_input_string_arr = "    aide:AddTmpInputEvents(ui.{0}s,view,view.On{1}Events)\n";
    public const string template_tmp_input_action_arr = @"
function {0}:On{1}Events(input,text,index)
       
end
";

    //slider
    public const string template_slider_string_arr = "    aide:AddSliderEvents(ui.{0}s,view,view.On{1}Events)\n";
    public const string template_slider_action_arr = @"
function {0}:On{1}Events(slider,v,index)
       
end
";

    #endregion


    #region VIEW_TEMPLATE
    public const string template_injection_lua2 = "    ui.{0} = aide:GetLuaBehaviour(self.{1})\n";
    public const string template_injection_template2 = "    ui.{0} = aide:GetComponent(self.{1},{2})\n";
    public const string template_button_string2 = "    aide:AddButtonEvent(ui.{0},self,self.On{1}Event)\n";
    public const string template_button_action2 = @"
function {0}:On{1}Event(button)
       
end
";

    //toggle event
    public const string template_toggle_string2 = "    aide:AddToggleEvent(ui.{0},self,self.On{1}Event)\n";
    public const string template_toggle_action2 = @"
function {0}:On{1}Event(toggle,v)
       
end
";

    //inputfield event
    public const string template_input_string2 = "    aide:AddInputEvent(ui.{0},self,self.On{1}Event)\n";
    public const string template_input_action2 = @"
function {0}:On{1}Event(input,text,eventname)
       
end
";

    //tmpinputfield
    public const string template_tmp_inputfield_string2 = "    aide:AddTmpInputEvent(ui.{0},self,self.On{1}Event)\n";
    public const string template_tmp_inputfield_action2 = @"
function {0}:On{1}Event(input,text,eventname)
       
end
";

    //slider
    public const string template_slider_string2 = "    aide:AddSliderEvent(ui.{0},self,self.On{1}Event)\n";
    public const string template_slider_action2 = @"
function {0}:On{1}Event(slider,v)
       
end
";

    public const string template_injection_lua_arr2 = "    ui.{0}s = aide:GetLuaBehaviours(self.{1})\n";
    public const string template_injection_template_arr2 = "    ui.{0}s = aide:GetComponents(self.{1},{2})\n";
    public const string template_button_string_arr2 = "    aide:AddButtonEvents(ui.{0}s,self,self.On{1}Events)\n";
    public const string template_button_action_arr2 = @"
function {0}:On{1}Events(button,index)
       
end
";
    public const string template_toggle_string_arr2 = "    aide:AddToggleEvents(ui.{0}s,self,self.On{1}Events)\n";
    public const string template_toggle_action_arr2 = @"
function {0}:On{1}Events(toggle,v,index)
       
end
";

    public const string template_input_string_arr2 = "    aide:AddInputEvents(ui.{0}s,self,self.On{1}Events)\n";
    public const string template_input_action_arr2 = @"
function {0}:On{1}Events(input,text,index)
       
end
";

    public const string template_tmp_inputfield_string_arr2 = "    aide:AddTmpInputEvents(ui.{0}s,self,self.On{1}Events)\n";
    public const string template_tmp_inputfield_action_arr2 = @"
function {0}:On{1}Events(input,text,index,eventname)
       
end
";


    //slider
    public const string template_slider_string_arr2 = "    aide:AddSliderEvents(ui.{0}s,self,self.On{1}Events)\n";
    public const string template_slider_action_arr2 = @"
function {0}:On{1}Events(slider,v,index)
       
end
";

    #endregion

    public const string template_module_manager = @"local _ENV = require ""Plazz.Lua.Module.Manager.ModuleEnv""
local model = require ""#K.Lua.Module.#1.#1Model""

local #1Manager = class(""#1Manager"", ModuleBase)

------------------------------------------------------------------------------
--公共方法
------------------------------------------------------------------------------
function #1Manager:Init()
    self.ip = ConfigCenter.NetConfig.plazz
end

function #1Manager:Reset()

end

return #1Manager
";

    public const string template_module_model = @"local #1Model = {}

function #1Model.New()
	local obj = {

	}
	return obj
end

return #1Model

";

}
