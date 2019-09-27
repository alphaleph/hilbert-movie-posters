import { BaseAction, UiGlobalsState } from '../../../types/index';
import { THEME_SETTING, THEME_DEFAULT, SR_SETTING, SR_OFF, ANIMATION_SETTING, ANIMATIONS_ON } from '../../constants';

const initialState = {
    theme: THEME_DEFAULT as THEME_DEFAULT,
    srMode: SR_OFF as SR_OFF,
    animationMode: ANIMATIONS_ON as ANIMATIONS_ON
}

export const UiGlobalsReducer = (state: UiGlobalsState = initialState, action: BaseAction): UiGlobalsState => {
    switch (action.type) {
        default:
            return state;
    }
}