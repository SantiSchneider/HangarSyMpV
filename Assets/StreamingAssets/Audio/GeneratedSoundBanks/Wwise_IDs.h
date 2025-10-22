/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID PLAY_AMBIENT = 1562304622U;
        static const AkUniqueID PLAY_AMBIENT_RANDOM = 4149338432U;
        static const AkUniqueID PLAY_FOOTSTEPS = 3854155799U;
        static const AkUniqueID PLAY_HEALTH = 3047160268U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace PLAYERALIVE
        {
            static const AkUniqueID GROUP = 2557321869U;

            namespace STATE
            {
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID PLAYERALIVEFALSE = 3056349874U;
                static const AkUniqueID PLAYERALIVETRUE = 2569559561U;
            } // namespace STATE
        } // namespace PLAYERALIVE

        namespace REVERB_HANGAR
        {
            static const AkUniqueID GROUP = 3404403065U;

            namespace STATE
            {
                static const AkUniqueID HANGAROFF = 1421091739U;
                static const AkUniqueID HANGARON = 1909259815U;
                static const AkUniqueID NONE = 748895195U;
            } // namespace STATE
        } // namespace REVERB_HANGAR

    } // namespace STATES

    namespace SWITCHES
    {
        namespace FOOTSTEPS
        {
            static const AkUniqueID GROUP = 2385628198U;

            namespace SWITCH
            {
                static const AkUniqueID FOOTSTEPS_PAVIMENTO = 1969272162U;
                static const AkUniqueID FOOTSTEPS_SAND = 444235487U;
            } // namespace SWITCH
        } // namespace FOOTSTEPS

    } // namespace SWITCHES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID CLIMA = 1819394459U;
        static const AkUniqueID HEALTH = 3677180323U;
    } // namespace GAME_PARAMETERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID MAINSOUNDBANK = 534561221U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
        static const AkUniqueID PLAYER = 1069431850U;
        static const AkUniqueID REVERB = 348963605U;
    } // namespace BUSSES

    namespace AUX_BUSSES
    {
        static const AkUniqueID REVERB_HANGAR = 3404403065U;
    } // namespace AUX_BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
