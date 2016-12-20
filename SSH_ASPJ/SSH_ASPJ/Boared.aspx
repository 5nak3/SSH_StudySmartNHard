﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Boared.aspx.cs" Inherits="Imagin.Boared" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        /* Some CSS styling */
        .rightside {
            float: left;
            margin-left: 10px;
        }

        #sketchpad {
            float: left;
            height: 300px;
            width: 400px;
            border: 2px solid #888;
            border-radius: 4px;
            position: relative; /* Necessary for correct mouse co-ords in Firefox */
        }

        #clear_button, #save_button {
            float: left;
            font-size: 15px;
            padding: 10px;
            -webkit-appearance: none;
            background: #eee;
            border: 1px solid #888;
            margin-bottom: 5px;
        }
    </style>

    <div id="sketchpadapp">
        <div class="rightside">
            <input type="submit"
                   value="Clear Canvas" id="clear_button" />
            <br />
            <canvas id="sketchpad" height="300"
                    width="400"></canvas>
        </div>
    </div>
    <title>SignalR Sketchpad</title>
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="Scripts/jquery.signalR-2.2.1.js"></script>
    <script src="/signalr/hubs"></script>
    <script type="text/javascript">

        $(function () {
            // Variables for referencing the canvas and 2dcanvas context
            var canvas, ctx;
            // Variables to keep track of the mouse position and left-button status
            var mouseX, mouseY, mouseDown = 0;

            init();

            //Create the SignalR Connection
            var DOT = $.connection.drawDot;
            //Start the SignalR hub
            $.connection.hub.start().done();
            //Function called from DrawDot Server
            DOT.client.updateDot = function (x, y) {
                drawDot(x, y, 8);
            };
            //Function called from DrawDot Server
            DOT.client.clearCanvas = function (x, y) {
                clearCanvas();
            };
            //////////////////////////////////////////////////////

            // Draws a dot at a specific position on the supplied canvas name
            // Parameters are: A canvas context, the x position, the y position, the size of the dot
            function drawDot(x, y, size) {
                // Let's use black by setting RGB values to 0, and 255 alpha (completely opaque)
                r = 0; g = 0; b = 0; a = 255;
                // Select a fill style
                
                // Draw a filled circle
                ctx.beginPath();
                ctx.arc(x, y, size, 0, Math.PI * 2, true);
                ctx.fillStyle = "black";
                ctx.closePath();
                ctx.fill();
            }
            // Clear the canvas context using the canvas width and height
            function cleanCanvas() {
                clearCanvas();
                DOT.server.clearCanvas();
            }
            function clearCanvas() {
                ctx.clearRect(0, 0, canvas.width, canvas.height);
            }
            // Keep track of the mouse button being pressed and draw a dot at current location
            function sketchpad_mouseDown() {
                mouseDown = 1;
                drawDot(mouseX, mouseY, 8);
                DOT.server.updateCanvas(mouseX, mouseY);
            }
            // Keep track of the mouse button being released
            function sketchpad_mouseUp() {
                mouseDown = 0;
            }
            // Keep track of the mouse position and draw a dot if mouse button is currently pressed
            function sketchpad_mouseMove(e) {
                // Update the mouse co-ordinates when moved
                getMousePos(e);
                // Draw a dot if the mouse button is currently being pressed
                if (mouseDown == 1) {
                    drawDot(mouseX, mouseY, 8);
                    DOT.server.updateCanvas(mouseX, mouseY);
                }
            }
            // Get the current mouse position relative to the top-left of the canvas
            function getMousePos(e) {
                if (!e)
                    var e = event;
                if (e.offsetX) {
                    mouseX = e.offsetX;
                    mouseY = e.offsetY;
                }
                else if (e.layerX) {
                    mouseX = e.layerX;
                    mouseY = e.layerY;
                }
            }
            // Set-up the canvas and add our event handlers after the page has loaded
            function init() {
                // Get the specific canvas element from the HTML document
                canvas = document.getElementById('sketchpad');
                // If the browser supports the canvas tag, get the 2d drawing context for this canvas
                if (canvas.getContext)
                    ctx = canvas.getContext('2d');
                // Check that we have a valid context to draw on/with before adding event handlers
                if (ctx) {
                    // React to mouse events on the canvas, and mouseup on the entire document
                    canvas.addEventListener('mousedown', sketchpad_mouseDown, false);
                    canvas.addEventListener('mousemove', sketchpad_mouseMove, false);
                    window.addEventListener('mouseup', sketchpad_mouseUp, false);
                }
                else {
                    document.write("Browser not supported!!");
                }
            }
        })
        
    </script>

</asp:Content>