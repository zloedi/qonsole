using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using GalliumMath;

using static SDL2.SDL;
using static SDL2.SDL.SDL_WindowFlags;
using static SDL2.SDL.SDL_EventType;
using static SDL2.SDL.SDL_TextureAccess;
using static SDL2.SDL.SDL_BlendMode;

namespace SDLPorts {
    public enum KeyCode {
        None, //Not assigned (never returned as the result of a keystroke).
        Backspace, //The backspace key.
        Delete, //The forward delete key.
        Tab, //The tab key.
        Clear, //The Clear key.
        Return, //Return key.
        Pause, //Pause on PC machines.
        Escape, //Escape key.
        Space, //Space key.
        Keypad0, //Numeric keypad 0.
        Keypad1, //Numeric keypad 1.
        Keypad2, //Numeric keypad 2.
        Keypad3, //Numeric keypad 3.
        Keypad4, //Numeric keypad 4.
        Keypad5, //Numeric keypad 5.
        Keypad6, //Numeric keypad 6.
        Keypad7, //Numeric keypad 7.
        Keypad8, //Numeric keypad 8.
        Keypad9, //Numeric keypad 9.
        KeypadPeriod, //Numeric keypad '.'.
        KeypadDivide, //Numeric keypad '/'.
        KeypadMultiply, //Numeric keypad '*'.
        KeypadMinus, //Numeric keypad '='.
        KeypadPlus, //Numeric keypad '+'.
        KeypadEnter, //Numeric keypad enter.
        KeypadEquals, //Numeric keypad '='.
        UpArrow, //Up arrow key.
        DownArrow, //Down arrow key.
        RightArrow, //Right arrow key.
        LeftArrow, //Left arrow key.
        Insert, //Insert key key.
        Home, //Home key.
        End, //End key.
        PageUp, //Page up.
        PageDown, //Page down.
        F1, //F1 function key.
        F2, //F2 function key.
        F3, //F3 function key.
        F4, //F4 function key.
        F5, //F5 function key.
        F6, //F6 function key.
        F7, //F7 function key.
        F8, //F8 function key.
        F9, //F9 function key.
        F10, //F10 function key.
        F11, //F11 function key.
        F12, //F12 function key.
        F13, //F13 function key.
        F14, //F14 function key.
        F15, //F15 function key.
        Alpha0, //The '0' key on the top of the alphanumeric keyboard.
        Alpha1, //The '1' key on the top of the alphanumeric keyboard.
        Alpha2, //The '2' key on the top of the alphanumeric keyboard.
        Alpha3, //The '3' key on the top of the alphanumeric keyboard.
        Alpha4, //The '4' key on the top of the alphanumeric keyboard.
        Alpha5, //The '5' key on the top of the alphanumeric keyboard.
        Alpha6, //The '6' key on the top of the alphanumeric keyboard.
        Alpha7, //The '7' key on the top of the alphanumeric keyboard.
        Alpha8, //The '8' key on the top of the alphanumeric keyboard.
        Alpha9, //The '9' key on the top of the alphanumeric keyboard.
        Exclaim, //Exclamation mark key '!'.
        DoubleQuote, //Double quote key '"'.
        Hash, //Hash key '#'.
        Dollar, //Dollar sign key '$'.
        Ampersand, //Ampersand key '&'.
        Quote, //Quote key '.
        LeftParen, //Left Parenthesis key '('.
        RightParen, //Right Parenthesis key ')'.
        Asterisk, //Asterisk key '*'.
        Plus, //Plus key '+'.
        Comma, //Comma ',' key.
        Minus, //Minus '-' key.
        Equals, //Equals '=' key.
        Period, //Period '.' key.
        Slash, //Slash '/' key.
        Colon, //Colon ':' key.
        Semicolon, //Semicolon ',' key.
        Less, //Less than '' key.
        Question, //Question mark '?' key.
        At, //At key '@'.
        LeftBracket, //Left square bracket key '['.
        Backslash, //Backslash key '\'.
        RightBracket, //Right square bracket key ']'.
        Caret, //Caret key '^'.
        Underscore, //Underscore '_' key.
        BackQuote, //Back quote key '`'.
        A, //'a' key.
        B, //'b' key.
        C, //'c' key.
        D, //'d' key.
        E, //'e' key.
        F, //'f' key.
        G, //'g' key.
        H, //'h' key.
        I, //'i' key.
        J, //'j' key.
        K, //'k' key.
        L, //'l' key.
        M, //'m' key.
        N, //'n' key.
        O, //'o' key.
        P, //'p' key.
        Q, //'q' key.
        R, //'r' key.
        S, //'s' key.
        T, //'t' key.
        U, //'u' key.
        V, //'v' key.
        W, //'w' key.
        X, //'x' key.
        Y, //'y' key.
        Z, //'z' key.
        Numlock, //Numlock key.
        CapsLock, //Capslock key.
        ScrollLock, //Scroll lock key.
        RightShift, //Right shift key.
        LeftShift, //Left shift key.
        RightControl, //Right Control key.
        LeftControl, //Left Control key.
        RightAlt, //Right Alt key.
        LeftAlt, //Left Alt key.

        // already added (not unique)
        // KeyCode.LeftCommand, //Left Command key.

        LeftApple, //Left Command key.
        LeftWindows, //Left Windows key.
        RightCommand, //Right Command key.

        // already added (not unique)
        //KeyCode.RightApple, //Right Command key.

        RightWindows, //Right Windows key.
        AltGr, //Alt Gr key.
        Help, //Help key.
        Print, //Print key.
        SysReq, //Sys Req key.
        Break, //Break key.
        Menu, //Menu key.
        Mouse0, //First (primary) mouse button.
        Mouse1, //Second (secondary) mouse button.
        Mouse2, //Third mouse button.
        Mouse3, //Fourth mouse button.
        Mouse4, //Fifth mouse button.
        Mouse5, //Sixth mouse button.
        Mouse6, //Seventh mouse button.

#if false // no joystick
        JoystickButton0, //Button 0 on any joystick.
        JoystickButton1, //Button 1 on any joystick.
        JoystickButton2, //Button 2 on any joystick.
        JoystickButton3, //Button 3 on any joystick.
        JoystickButton4, //Button 4 on any joystick.
        JoystickButton5, //Button 5 on any joystick.
        JoystickButton6, //Button 6 on any joystick.
        JoystickButton7, //Button 7 on any joystick.
        JoystickButton8, //Button 8 on any joystick.
        JoystickButton9, //Button 9 on any joystick.
        JoystickButton10, //Button 10 on any joystick.
        JoystickButton11, //Button 11 on any joystick.
        JoystickButton12, //Button 12 on any joystick.
        JoystickButton13, //Button 13 on any joystick.
        JoystickButton14, //Button 14 on any joystick.
        JoystickButton15, //Button 15 on any joystick.
        JoystickButton16, //Button 16 on any joystick.
        JoystickButton17, //Button 17 on any joystick.
        JoystickButton18, //Button 18 on any joystick.
        JoystickButton19, //Button 19 on any joystick.
        Joystick1Button0, //Button 0 on first joystick.
        Joystick1Button1, //Button 1 on first joystick.
        Joystick1Button2, //Button 2 on first joystick.
        Joystick1Button3, //Button 3 on first joystick.
        Joystick1Button4, //Button 4 on first joystick.
        Joystick1Button5, //Button 5 on first joystick.
        Joystick1Button6, //Button 6 on first joystick.
        Joystick1Button7, //Button 7 on first joystick.
        Joystick1Button8, //Button 8 on first joystick.
        Joystick1Button9, //Button 9 on first joystick.
        Joystick1Button10, //Button 10 on first joystick.
        Joystick1Button11, //Button 11 on first joystick.
        Joystick1Button12, //Button 12 on first joystick.
        Joystick1Button13, //Button 13 on first joystick.
        Joystick1Button14, //Button 14 on first joystick.
        Joystick1Button15, //Button 15 on first joystick.
        Joystick1Button16, //Button 16 on first joystick.
        Joystick1Button17, //Button 17 on first joystick.
        Joystick1Button18, //Button 18 on first joystick.
        Joystick1Button19, //Button 19 on first joystick.
        Joystick2Button0, //Button 0 on second joystick.
        Joystick2Button1, //Button 1 on second joystick.
        Joystick2Button2, //Button 2 on second joystick.
        Joystick2Button3, //Button 3 on second joystick.
        Joystick2Button4, //Button 4 on second joystick.
        Joystick2Button5, //Button 5 on second joystick.
        Joystick2Button6, //Button 6 on second joystick.
        Joystick2Button7, //Button 7 on second joystick.
        Joystick2Button8, //Button 8 on second joystick.
        Joystick2Button9, //Button 9 on second joystick.
        Joystick2Button10, //Button 10 on second joystick.
        Joystick2Button11, //Button 11 on second joystick.
        Joystick2Button12, //Button 12 on second joystick.
        Joystick2Button13, //Button 13 on second joystick.
        Joystick2Button14, //Button 14 on second joystick.
        Joystick2Button15, //Button 15 on second joystick.
        Joystick2Button16, //Button 16 on second joystick.
        Joystick2Button17, //Button 17 on second joystick.
        Joystick2Button18, //Button 18 on second joystick.
        Joystick2Button19, //Button 19 on second joystick.
        Joystick3Button0, //Button 0 on third joystick.
        Joystick3Button1, //Button 1 on third joystick.
        Joystick3Button2, //Button 2 on third joystick.
        Joystick3Button3, //Button 3 on third joystick.
        Joystick3Button4, //Button 4 on third joystick.
        Joystick3Button5, //Button 5 on third joystick.
        Joystick3Button6, //Button 6 on third joystick.
        Joystick3Button7, //Button 7 on third joystick.
        Joystick3Button8, //Button 8 on third joystick.
        Joystick3Button9, //Button 9 on third joystick.
        Joystick3Button10, //Button 10 on third joystick.
        Joystick3Button11, //Button 11 on third joystick.
        Joystick3Button12, //Button 12 on third joystick.
        Joystick3Button13, //Button 13 on third joystick.
        Joystick3Button14, //Button 14 on third joystick.
        Joystick3Button15, //Button 15 on third joystick.
        Joystick3Button16, //Button 16 on third joystick.
        Joystick3Button17, //Button 17 on third joystick.
        Joystick3Button18, //Button 18 on third joystick.
        Joystick3Button19, //Button 19 on third joystick.
        Joystick4Button0, //Button 0 on forth joystick.
        Joystick4Button1, //Button 1 on forth joystick.
        Joystick4Button2, //Button 2 on forth joystick.
        Joystick4Button3, //Button 3 on forth joystick.
        Joystick4Button4, //Button 4 on forth joystick.
        Joystick4Button5, //Button 5 on forth joystick.
        Joystick4Button6, //Button 6 on forth joystick.
        Joystick4Button7, //Button 7 on forth joystick.
        Joystick4Button8, //Button 8 on forth joystick.
        Joystick4Button9, //Button 9 on forth joystick.
        Joystick4Button10, //Button 10 on forth joystick.
        Joystick4Button11, //Button 11 on forth joystick.
        Joystick4Button12, //Button 12 on forth joystick.
        Joystick4Button13, //Button 13 on forth joystick.
        Joystick4Button14, //Button 14 on forth joystick.
        Joystick4Button15, //Button 15 on forth joystick.
        Joystick4Button16, //Button 16 on forth joystick.
        Joystick4Button17, //Button 17 on forth joystick.
        Joystick4Button18, //Button 18 on forth joystick.
        Joystick4Button19, //Button 19 on forth joystick.
        Joystick5Button0, //Button 0 on fifth joystick.
        Joystick5Button1, //Button 1 on fifth joystick.
        Joystick5Button2, //Button 2 on fifth joystick.
        Joystick5Button3, //Button 3 on fifth joystick.
        Joystick5Button4, //Button 4 on fifth joystick.
        Joystick5Button5, //Button 5 on fifth joystick.
        Joystick5Button6, //Button 6 on fifth joystick.
        Joystick5Button7, //Button 7 on fifth joystick.
        Joystick5Button8, //Button 8 on fifth joystick.
        Joystick5Button9, //Button 9 on fifth joystick.
        Joystick5Button10, //Button 10 on fifth joystick.
        Joystick5Button11, //Button 11 on fifth joystick.
        Joystick5Button12, //Button 12 on fifth joystick.
        Joystick5Button13, //Button 13 on fifth joystick.
        Joystick5Button14, //Button 14 on fifth joystick.
        Joystick5Button15, //Button 15 on fifth joystick.
        Joystick5Button16, //Button 16 on fifth joystick.
        Joystick5Button17, //Button 17 on fifth joystick.
        Joystick5Button18, //Button 18 on fifth joystick.
        Joystick5Button19, //Button 19 on fifth joystick.
        Joystick6Button0, //Button 0 on sixth joystick.
        Joystick6Button1, //Button 1 on sixth joystick.
        Joystick6Button2, //Button 2 on sixth joystick.
        Joystick6Button3, //Button 3 on sixth joystick.
        Joystick6Button4, //Button 4 on sixth joystick.
        Joystick6Button5, //Button 5 on sixth joystick.
        Joystick6Button6, //Button 6 on sixth joystick.
        Joystick6Button7, //Button 7 on sixth joystick.
        Joystick6Button8, //Button 8 on sixth joystick.
        Joystick6Button9, //Button 9 on sixth joystick.
        Joystick6Button10, //Button 10 on sixth joystick.
        Joystick6Button11, //Button 11 on sixth joystick.
        Joystick6Button12, //Button 12 on sixth joystick.
        Joystick6Button13, //Button 13 on sixth joystick.
        Joystick6Button14, //Button 14 on sixth joystick.
        Joystick6Button15, //Button 15 on sixth joystick.
        Joystick6Button16, //Button 16 on sixth joystick.
        Joystick6Button17, //Button 17 on sixth joystick.
        Joystick6Button18, //Button 18 on sixth joystick.
        Joystick6Button19, //Button 19 on sixth joystick.
        Joystick7Button0, //Button 0 on seventh joystick.
        Joystick7Button1, //Button 1 on seventh joystick.
        Joystick7Button2, //Button 2 on seventh joystick.
        Joystick7Button3, //Button 3 on seventh joystick.
        Joystick7Button4, //Button 4 on seventh joystick.
        Joystick7Button5, //Button 5 on seventh joystick.
        Joystick7Button6, //Button 6 on seventh joystick.
        Joystick7Button7, //Button 7 on seventh joystick.
        Joystick7Button8, //Button 8 on seventh joystick.
        Joystick7Button9, //Button 9 on seventh joystick.
        Joystick7Button10, //Button 10 on seventh joystick.
        Joystick7Button11, //Button 11 on seventh joystick.
        Joystick7Button12, //Button 12 on seventh joystick.
        Joystick7Button13, //Button 13 on seventh joystick.
        Joystick7Button14, //Button 14 on seventh joystick.
        Joystick7Button15, //Button 15 on seventh joystick.
        Joystick7Button16, //Button 16 on seventh joystick.
        Joystick7Button17, //Button 17 on seventh joystick.
        Joystick7Button18, //Button 18 on seventh joystick.
        Joystick7Button19, //Button 19 on seventh joystick.
        Joystick8Button0, //Button 0 on eighth joystick.
        Joystick8Button1, //Button 1 on eighth joystick.
        Joystick8Button2, //Button 2 on eighth joystick.
        Joystick8Button3, //Button 3 on eighth joystick.
        Joystick8Button4, //Button 4 on eighth joystick.
        Joystick8Button5, //Button 5 on eighth joystick.
        Joystick8Button6, //Button 6 on eighth joystick.
        Joystick8Button7, //Button 7 on eighth joystick.
        Joystick8Button8, //Button 8 on eighth joystick.
        Joystick8Button9, //Button 9 on eighth joystick.
        Joystick8Button10, //Button 10 on eighth joystick.
        Joystick8Button11, //Button 11 on eighth joystick.
        Joystick8Button12, //Button 12 on eighth joystick.
        Joystick8Button13, //Button 13 on eighth joystick.
        Joystick8Button14, //Button 14 on eighth joystick.
        Joystick8Button15, //Button 15 on eighth joystick.
        Joystick8Button16, //Button 16 on eighth joystick.
        Joystick8Button17, //Button 17 on eighth joystick.
        Joystick8Button18, //Button 18 on eighth joystick.
        Joystick8Button19, //Button 19 on eighth joystick.
#endif
    }

    public enum FilterMode {
        Point,
    }

    public enum HideFlags {
        HideAndDontSave,
    }

    public enum TextureFormat {
        RGBA32,
    }

    public static class Application {
        public static bool isFocused;
        public static bool isPlaying;
        public static bool isEditor;
        public static string persistentDataPath = "./";

        public static IntPtr renderer;
        public static IntPtr window;
        public static long nowMs;
        public static int deltaMs;

        public static void Run( string [] argv, Action init, Action run, Action done ) {
            try {

            SDL_Init( SDL_INIT_VIDEO );
            SDL_WindowFlags flags = SDL_WINDOW_RESIZABLE;
            SDL_CreateWindowAndRenderer( 1024, 768, flags, out window, out renderer );
            SDL_SetWindowTitle( window, "Radical Rumble" );

            Qonsole.Init();
            Qonsole.Start();
            Qonsole.Toggle();
            Qonsole.Log( Guid.NewGuid() );

            QGL.Log = o => Qonsole.Log( "QGL: " + o );
            QGL.Error = s => Qonsole.Error( "QGL: " + s );

            QGL.Start();

            KeyBinds.Log = s => Qonsole.Log( "Keybinds: " + s );
            KeyBinds.Error = s => Qonsole.Error( "Keybinds: " + s );

            while ( true ) {
                SDL_GetWindowSize( window, out int w, out int h );
                Screen.width = w;
                Screen.height = h;

                Time.Tick();

                while ( SDL_PollEvent( out SDL_Event ev ) != 0 ) {
                    SDL_Keycode code = ev.key.keysym.sym;
                    switch( ev.type ) {
            //            case SDL_TEXTINPUT:
            //                //QON_Insert( ev.text.text );
            //                break;
            //            case SDL_KEYDOWN:
            //                //switch ( code ) {
            //                //    case SDLK_RIGHT:     QON_MoveRight( 1 ); break;
            //                //    case SDLK_LEFT:      QON_MoveLeft( 1 );  break;
            //                //    case SDLK_DELETE:    QON_Delete( 1 );    break;
            //                //    case SDLK_BACKSPACE: QON_Backspace( 1 ); break;
            //                //    case SDLK_PAGEUP:    QON_PageUp();       break;
            //                //    case SDLK_PAGEDOWN:  QON_PageDown();     break;
            //                //    case SDLK_RETURN: {
            //                //        char buf[64];
            //                //        QON_EmitCommand( sizeof( buf ), buf );
            //                //    }
            //                //    break;
            //                //    default: break;
            //                //}
            //                //break;
            //
            //                      case SDL_MOUSEMOTION:
            //                              //mouseX = ev.motion.x;
            //                //mouseY = ev.motion.y;
            //                              break;
            //
            //            case SDL_MOUSEBUTTONDOWN:
            //                //ZH_UI_OnMouseButton( 1 );
            //                break;
            //
            //            case SDL_MOUSEBUTTONUP:
            //                //ZH_UI_OnMouseButton( 0 );
            //                break;
            //
                        case SDL_QUIT:
                            goto done;

                        default:
                            break;
                    }
                }

                SDL_SetRenderDrawColor( renderer, 40, 45, 50, 255 );
                SDL_RenderClear( renderer );

                //QGL.Begin();
                //QGL.LateBlit( AppleFont.GetTexture(), 100, 100, 100, 100, angle: Time.time * 0.3f );

                QGL.LatePrint( Time.deltaTime.ToString("0.00"), 200, 100 );
                //if ( ! Qonsole.SDLTick( renderer, window ) ) {
                //    goto done;
                //}

                //QON_Draw( ( w - CON_X * 2 ) / cellW, ( h - CON_Y * 2 ) / cellH );
                //ZH_UI_Begin( mouseX, mouseY );
                //ZH_UI_End();

                Qonsole.SDLTick();

                //QGL.End();
                SDL_RenderPresent( renderer );
            }

done:

            SDL_DestroyRenderer( renderer );
            SDL_DestroyWindow( window );
            SDL_Quit();

            } catch ( Exception e ) {
                Qonsole.Error( e );
            }
        }
    }

    public static class Time {
        public static float deltaTime;
        public static float realtimeSinceStartup;
        public static float unscaledTime;
        public static float time;

        static ulong _beginTime;
        static ulong _last;
        static ulong _now;
        static double _deltaTimeDouble = 0;
        static double _timeSinceStartDouble = 0;

        public static void Tick() {
            if ( _beginTime == 0 ) {
                _beginTime = SDL_GetPerformanceCounter();
            }

            _last = _now;
            _now = SDL_GetPerformanceCounter();

            _deltaTimeDouble = (double)((_now - _last) / (double)SDL_GetPerformanceFrequency() );
            _timeSinceStartDouble = (double)((_now - _beginTime) / (double)SDL_GetPerformanceFrequency() );

            deltaTime = ( float )_deltaTimeDouble;
            time = unscaledTime = realtimeSinceStartup = ( float )_timeSinceStartDouble;
        }
    }

    public static class Input {
        public static Vector2 mousePosition;
        public static bool GetKeyDown( KeyCode kc ) { return false; }
        public static bool GetKeyUp( KeyCode kc ) { return false; }
    }

    public static class Screen {
        public static int width, height;
    }

    public class Camera {
        public int pixelWidth, pixelHeight;

        public static implicit operator bool( Camera c ) => c != null;
        public static Camera main = null;//new Camera();

        public Vector2 WorldToScreenPoint( Vector3 pt ) { return Vector2.zero; }
    }

    public class Texture {
        public int width, height;
        public static implicit operator bool( Texture t ) => t != null;
        public IntPtr sdlTex;
    }

    public class Texture2D : Texture {
        public FilterMode filterMode;

        public Texture2D() {}

        public Texture2D( int width, int height ) {
            Create( width, height );
        }

        public Texture2D( int width, int height, TextureFormat textureFormat,
                                                                    bool mipChain, bool linear ) {
            Create( width, height );
        }

        public static Texture2D whiteTexture = new Texture2D();

        List<byte> _buf = new List<byte>();
        public void SetPixel( int x, int y, Color32 color ) {
            int pitch = width * 4;
            int sz = pitch * height;
            if ( _buf.Count != sz ) {
                _buf.Clear();
                for ( int i = 0; i < sz; i++ ) {
                    _buf.Add( 0 );
                }
            }
            _buf[x * 4 + y * pitch + 0] = color.r;
            _buf[x * 4 + y * pitch + 1] = color.b;
            _buf[x * 4 + y * pitch + 2] = color.g;
            _buf[x * 4 + y * pitch + 3] = color.a;
        }

        public void Apply() {
            Update( _buf.ToArray() );
            _buf.Clear();
        }

        void Create( int w, int h ) {
            width = w;
            height = h;
            SDL_SetHint( SDL_HINT_RENDER_SCALE_QUALITY, "0" );
            sdlTex = SDL_CreateTexture( Application.renderer, SDL_PIXELFORMAT_ABGR8888, 
                                                ( int )SDL_TEXTUREACCESS_STATIC, width, height );
        }

        void Update( byte [] bytes ) {
            IntPtr unmanagedPointer = Marshal.AllocHGlobal( bytes.Length );
            Marshal.Copy( bytes, 0, unmanagedPointer, bytes.Length );
            SDL_UpdateTexture( sdlTex, IntPtr.Zero, unmanagedPointer, width * 4 );
        }
    }

    public class Shader {
        public static implicit operator bool( Shader sh ) => sh != null;
        public static Shader Find( string name ) { return new Shader(); }
    }

    public class Material {
        public static implicit operator bool( Material mat ) => mat != null;
        public Color color;
        public Texture texture;

        public Material( Shader s ) {}

        public void SetPass( int p ) {
            GL.texture = texture;
        }

        public void SetTexture( string name, Texture tex ) {
            texture = tex;
        }

        public void SetColor( string name, Color val ) {}

        public HideFlags hideFlags;
    }

    public static class GL {
        public const int QUADS = 0;
        public const int LINES = 1;

        public static Texture texture;

        const int MAX_VERTS = 128 * 1024;
        const int MAX_INDS = 128 * 1024;

        static SDL_Color _color;
        static int _numVertices;
        static SDL_Vertex [] _vertices = new SDL_Vertex[MAX_VERTS];

        static int _numIndices;
        static int [] _indices = new int[MAX_INDS];
        
        public static void Begin( int mode ) {
            _numVertices = 0;
            _numIndices = 0;
        }

        public static void End() {
            if ( _numVertices > MAX_VERTS ) {
                Qonsole.Error( $"Out of vertices: {_numVertices}" );
            }
            if ( _numIndices > MAX_INDS ) {
                Qonsole.Error( $"Out of indices: {_numIndices}" );
            }
            //SDL_SetRenderDrawColor( Application.renderer, 255, 255, 255, 255 );
            //SDL_SetRenderDrawBlendMode( Application.renderer, SDL_BLENDMODE_BLEND );
            SDL_SetTextureAlphaMod( texture.sdlTex, 0xff );
            SDL_SetTextureBlendMode( texture.sdlTex, SDL_BLENDMODE_BLEND );
            SDL_RenderGeometry(
                Application.renderer,
                texture.sdlTex,
                _vertices,
                _numVertices,
                _indices,
                _numIndices
            );
        }

        public static void Color( Color color ) {
            var c = new SDL_Color {
                r = ( byte )( color.r * 255f ),
                g = ( byte )( color.g * 255f ),
                b = ( byte )( color.b * 255f ),
                a = ( byte )( color.a * 255f ),
            };
            _color = c;
        }

        public static void TexCoord( Vector3 uv ) {
            var p = new SDL_FPoint { x = uv.x, y = uv.y };
            _vertices[_numVertices & ( MAX_VERTS - 1 )].tex_coord = p;
        }

        public static void Vertex( Vector3 v ) {
            var p = new SDL_FPoint { x = v.x, y = v.y };
            int nv = _numVertices & ( MAX_VERTS - 1 );

            _vertices[nv].position = p;
            _vertices[nv].color = _color;
            _numVertices++;

            if ( ( _numVertices & 3 ) == 0 ) {
                int mask = MAX_INDS - 1;
                int bv = ( _numVertices - 4 ) & ( MAX_VERTS - 1 );

                _indices[( _numIndices + 0 ) & mask] = bv + 0;
                _indices[( _numIndices + 1 ) & mask] = bv + 1;
                _indices[( _numIndices + 2 ) & mask] = bv + 2;

                _indices[( _numIndices + 3 ) & mask] = bv + 3;
                _indices[( _numIndices + 4 ) & mask] = bv + 0;
                _indices[( _numIndices + 5 ) & mask] = bv + 2;

                _numIndices = Mathf.Min( _numIndices + 6, MAX_INDS );
            }
        }

        public static void LoadPixelMatrix() {}
        public static void PushMatrix() {}
        public static void PopMatrix() {}
    }
}


