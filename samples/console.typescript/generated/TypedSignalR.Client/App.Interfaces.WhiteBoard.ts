/* THIS (.ts) FILE IS GENERATED BY TypedSignalR.Client.TypeScript */
/* eslint-disable */
/* tslint:disable */
import { ShapeType } from '../App.Interfaces.WhiteBoard';

export type IWhiteboardHub = {
    /**
    * @param shapeType Transpiled from App.Interfaces.WhiteBoard.ShapeType
    * @param x Transpiled from float
    * @param y Transpiled from float
    * @returns Transpiled from System.Threading.Tasks.Task<System.Guid>
    */
    add(shapeType: ShapeType, x: number, y: number): Promise<string>;
    /**
    * @param shapeId Transpiled from System.Guid
    * @returns Transpiled from System.Threading.Tasks.Task
    */
    move(shapeId: string): Promise<void>;
    /**
    * @param x Transpiled from float
    * @param y Transpiled from float
    * @returns Transpiled from System.Threading.Tasks.Task
    */
    writeLine(x: number, y: number): Promise<void>;
}

export type IWhiteboardReceiver = {
    /**
    * @param shapeId Transpiled from System.Guid
    * @param x Transpiled from float
    * @param y Transpiled from float
    * @returns Transpiled from System.Threading.Tasks.Task
    */
    onMove(shapeId: string, x: number, y: number): Promise<void>;
    /**
    * @param x Transpiled from float
    * @param y Transpiled from float
    * @returns Transpiled from System.Threading.Tasks.Task
    */
    onWriteLine(x: number, y: number): Promise<void>;
}

