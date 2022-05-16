let drawLine = (context, x1, y1, x2, y2, strokeStyle) =>
{
    context.beginPath();
    context.moveTo(x1, y1);
    context.lineTo(x2, y2);
    context.strokeStyle = strokeStyle || 'black';
    context.stroke();
    context.closePath();
}

let drawLines = (board, segments) => {
    let context = board.getContext('2d');
    
    for (var i = 0; i < segments.length; i++) {
        drawLine(context, segments[i].start.x, segments[i].start.y, segments[i].end.x, segments[i].end.y);
    }
 }
 
 export { drawLines };
 