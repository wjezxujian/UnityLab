using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar : MonoBehaviour
{
    public int mapWidth = 8;
    public int mapHeight = 6;
    Point[,] map;

    // Use this for initialization
    void Start()
    {
        map = new Point[mapWidth, mapHeight];
        InitMap();

        Point start = map[2, 3];
        Point end = map[6, 3];
        FindPath(start, end);
        ShowPath(start, end);

        //Test GetSurroundPoint()
        //List<Point> l = GetSurroundPoint(map[4, 1]);
        //foreach(Point p in l)
        //{
        //    Debug.Log(p.X + "_" + p.Y);
        //}
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ShowPath(Point start, Point end)
    {
        Point temp = end;
        while(true)
        {
            //Debug.Log(temp.X + "," + temp.Y);
            Color c = Color.gray;
            if(temp == start)
            {
                c = Color.green;
            }
            else if(temp == end)
            {
                c = Color.red;
            }
            CreateCube(temp.X, temp.Y, c);

            if(temp.Parent == null)
            {
                break;
            }
            temp = temp.Parent;
        }

        for (int x = 0; x < mapWidth; ++x)
        {
            for (int y = 0; y < mapHeight; ++y)
            {
                Color c;
                if (map[x, y].IsWall)
                {
                    c = Color.blue;
                }
                else
                {
                    c = Color.black;
                }
                CreateCube(x, y, c);
            }
        }
    }

    private void CreateCube(int x, int y, Color color)
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        go.transform.position = new Vector3(x, 0, y);
        go.GetComponent<Renderer>().material.color = color;
    }

    private void InitMap()
    {
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                map[x, y] = new Point(x, y);
            }
        }

        map[4, 2].IsWall = true;
        map[4, 3].IsWall = true;
        map[4, 4].IsWall = true;
    }

    private void FindPath(Point start, Point end)
    {
        List<Point> openList = new List<Point>();
        List<Point> closeList = new List<Point>();

        openList.Add(start);
        while(openList.Count != 0)
        {
            Point point = FindMinFofPoint(openList);
            openList.Remove(point);
            closeList.Add(point);

            List<Point> surroundPoints = GetSurroundPoint(point);
            PointsFilter(surroundPoints, closeList);

            foreach(Point surroundPoint in surroundPoints)
            {
                //存在
                if(openList.IndexOf(surroundPoint) > -1)
                {
                    float nowG = CalcG(surroundPoint, point);
                    if(nowG < surroundPoint.G)
                    {
                        surroundPoint.UpdateParent(point, nowG);
                    }
                    //否则不处理
                }
                else
                {
                    surroundPoint.Parent = point;
                    CalcF(surroundPoint, end);
                    openList.Add(surroundPoint);
                }
            }

            //判断end,是否在开启列表
            if(openList.IndexOf(end) > -1)
            {
                break;
            }
        }
    }
    private void PointsFilter(List<Point> src, List<Point> closeList)
    {
        foreach(Point p in closeList)
        {
            if(src.IndexOf(p) > -1)
            {
                src.Remove(p);
            }
        }


    }

    private List<Point> GetSurroundPoint(Point point)
    {
        List<Point> list = new List<Point>();

        Point up = null, down = null, left = null, right = null;
        Point upLeft = null, upRight = null, downLeft = null, downRight = null;
        if(point.Y < mapHeight - 1)
        {
            up = map[point.X, point.Y + 1];
        }

        if(point.Y > 0)
        {
            down = map[point.X, point.Y - 1];
        }

        if (point.X > 0)
        {
            left = map[point.X - 1,  point.Y];
        }

        if (point.X < mapWidth - 1)
        {
            right = map[point.X + 1, point.Y];
        }

        if(up !=null && left != null)
        {
            upLeft = map[point.X - 1, point.Y + 1];
        }
        ////
        if (up != null && right != null)
        {
            upRight = map[point.X + 1, point.Y + 1];
        }

        if (down != null && left != null)
        {
            downLeft = map[point.X - 1, point.Y - 1];
        }

        if (down != null && right != null)
        {
            downRight = map[point.X + 1, point.Y - 1];
        }

        /////////////////
        if (up != null && up.IsWall == false)
        {
            list.Add(up);
        }

        if(down!= null && down.IsWall == false)
        {
            list.Add(down);
        }

        if (left != null && left.IsWall == false)
        {
            list.Add(left);
        }

        if (right != null && right.IsWall == false)
        {
            list.Add(right);
        }

        /////////////////
        if (upLeft != null && !upLeft.IsWall && !up.IsWall && !left.IsWall)
        {
            list.Add(upLeft);
        }

        if (upRight != null && !upRight.IsWall && !up.IsWall && !right.IsWall)
        {
            list.Add(upRight);
        }

        if (downLeft != null && !downLeft.IsWall && !down.IsWall && !left.IsWall)
        {
            list.Add(downLeft);
        }

        if (downRight != null && !downRight.IsWall && !down.IsWall && !right.IsWall)
        {
            list.Add(downRight);
        }

        return list;
    }

    private Point FindMinFofPoint(List<Point> openList)
    {
        Point temp = null;
        float f = float.MaxValue;
        foreach(Point p in openList)
        {
            if(p.F < f)
            {
                temp = p;
                f = p.F;
            }
        }

        return temp;
    }

    private float CalcG(Point now, Point parent)
    {
        float g = 0;
        if(parent != null)
        {
            g = Vector2.Distance(new Vector2(now.X, now.Y), new Vector2(now.Parent.X, now.Parent.Y)) + +now.Parent.G;
            
        }
        return g;
    }


    private void CalcF(Point now, Point end)
    {
        // F = G + H
        float h = Mathf.Abs(end.X - now.X) + Mathf.Abs(end.Y - end.X);
        float g = CalcG(now, now.Parent);
        float f = g + h;

        now.F = f;
        now.G = g;
        now.H = h;
    }


}
